using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;
using System;

namespace PaymentContext.Domain.Handlers
{
    public class AssinaturaHandler : Notifiable<Notification>, IHandler<CriarAssinaturaBoletoCommand>
    {
        private readonly IAlunoRepository _alunoRepo;
        private readonly IEmailService _emailService;

        public AssinaturaHandler(IAlunoRepository alunoRepository, IEmailService emailService)
        {
            _alunoRepo = alunoRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CriarAssinaturaBoletoCommand command)
        {
            // Fail Fast Validations
            command.Validar();

            if (!command.IsValid)
            {
                command.AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar a assinatura.");
            }

            // Verificar se documento já está cadastrado
            if (_alunoRepo.DocumentoExiste(command.NumeroDocumento))
                command.AddNotification("Documento", "Este documento já está em uso.");

            // Verificar se e-mail já está cadastrado
            if (_alunoRepo.EmailExiste(command.Email))
                command.AddNotification("Documento", "Este e-mail já está em uso.");

            // Gerar os VOs
            var documento = new Documento(command.NumeroDocumento, ETipoDocumento.CPF);
            var email = new Email(command.Email);
            var endereco = new Endereco(command.Cep, command.Logradouro, command.Numero, command.Complemento, command.Bairro, command.Cidade, command.Estado, command.Pais);

            // Gerar as entidades
            var aluno = new Aluno("Amanda", "Nascimento", documento, email);
            var assinatura = new Assinatura(DateTime.Now.AddMonths(1));
            var pagamento = new PagamentoBoleto(
                command.DataPagamento,
                command.DataExpiracao,
                command.ValorTotal,
                command.ValorPagamento,
                command.Proprietario,
                new Documento(command.ProprietarioDocumento, command.ProprietarioDocumentoTipo),
                email,
                endereco,
                command.CodigoBarras,
                command.BoletoNumero
            );

            // Relacionamentos
            assinatura.AdicionarPagamento(pagamento);
            aluno.AdicionarAssinatura(assinatura);

            // Aplicar as validações
            AddNotifications(documento, email, endereco, aluno, assinatura, pagamento);

            // Checar as validações
            if (!IsValid)
                return new CommandResult(false, "Não foi possível realizar a assinatura.");

            // Salvar as informações
            _alunoRepo.CriarAssinatura(aluno);

            // Enviar e-mail de boas vindas
            _emailService.EnviarEmail($"{aluno.Nome} + {aluno.Sobrenome}", aluno.Email.Endereco, "Bem vindo ao projetinho.", "Sua assinatura foi criada.");

            // Retornar informações
            return new CommandResult(true, "Operação realizada com sucesso.");
        }
    }
}
