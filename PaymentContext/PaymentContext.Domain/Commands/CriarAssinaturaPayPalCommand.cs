using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;
using System;

namespace PaymentContext.Domain.Commands
{
    public class CriarAssinaturaPayPalCommand : Notifiable<Notification>, ICommand
    {
        // Entity: Aluno

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        // VO: Documento

        public string NumeroDocumento { get; set; }

        // VO: Email

        public string Email { get; set; }

        // Entity: PagamentoPayPal

        public string CodigoTransacao { get; set; }

        // Entity: Pagamento

        public string IdPagamento { get; set; }

        public DateTime DataPagamento { get; set; }

        public DateTime DataExpiracao { get; set; }

        public decimal ValorTotal { get; set; }

        public decimal ValorPagamento { get; set; }

        public string Proprietario { get; set; }

        public string ProprietarioDocumento { get; set; }

        public ETipoDocumento ProprietarioDocumentoTipo { get; set; }

        // Email

        public string ProprietarioEmail { get; set; }

        // Endereco

        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Pais { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract<CriarAssinaturaPayPalCommand>()
                .Requires()
                .IsNotNullOrEmpty(Nome, nameof(Nome), "Nome não foi preenchido.")
                .IsNotNullOrEmpty(Sobrenome, nameof(Sobrenome), "Sobrenome não foi preenchido.")
            );
        }

    }
}
