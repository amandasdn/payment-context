using Moq;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using System;
using Xunit;

namespace PaymentContext.Tests.Handlers
{
    public class AssinaturaHandlerTestes
    {
        Mock<IAlunoRepository> _alunoRepository;
        Mock<IEmailService> _emailService;

        public AssinaturaHandlerTestes()
        {
            _alunoRepository = new Mock<IAlunoRepository>();
            _emailService = new Mock<IEmailService>();
        }

        [Fact(DisplayName = "Assinatura Handler - Retornar Erro se possuir Documento")]
        public void TestarAssinaturaHandler_RetornarErroQuandoDocumentoExiste()
        {
            // Arrange
            var handler = new AssinaturaHandler(_alunoRepository.Object, _emailService.Object);
            CriarAssinaturaBoletoCommand command = new();

            command.Nome = "Amanda";
            command.Sobrenome = "Nascimento";
            command.NumeroDocumento = "00000000000";
            command.Email = "amanda@teste.com";
            command.CodigoBarras = "123456789";
            command.BoletoNumero = "1234654987";
            command.IdPagamento = Guid.NewGuid().ToString();
            command.DataPagamento = DateTime.Now;
            command.DataExpiracao = DateTime.Now.AddMonths(1);
            command.ValorTotal = 100;
            command.ValorPagamento = 100;
            command.Proprietario = "AMANDA CORP";
            command.ProprietarioDocumento = "11111111111";
            command.ProprietarioDocumentoTipo = ETipoDocumento.CPF;
            command.ProprietarioEmail = "teste@teste.com";
            command.Cep = "00000000";
            command.Logradouro = "Teste";
            command.Numero = "0";
            command.Bairro = "Teste";
            command.Cidade = "Teste";
            command.Estado = "Teste";
            command.Pais = "Teste";

            // Act
            handler.Handle(command);

            // Assert
            Assert.False(handler.IsValid);
        }
    }
}
