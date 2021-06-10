using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System;

namespace PaymentContext.Domain.Entities
{
    public abstract class Pagamento : Entidade
    {
        protected Pagamento (
            DateTime dataPagamento,
            DateTime dataExpiracao,
            decimal valorTotal,
            decimal valorPagamento,
            string proprietario,
            Documento documento,
            Email email,
            Endereco endereco)
        {
            IdPagamento = Guid.NewGuid().ToString().ToUpper().Replace("-","");
            DataPagamento = dataPagamento;
            DataExpiracao = dataExpiracao;
            ValorTotal = valorTotal;
            ValorPagamento = valorPagamento;
            Proprietario = proprietario;
            Documento = documento;
            Email = email;
            Endereco = endereco;

            AddNotifications(new Contract<Pagamento>()
                .Requires()
                .IsLowerThan(ValorTotal, 0, nameof(ValorTotal), "O valor total não pode ser zero.")
                .IsGreaterThan(ValorTotal, ValorPagamento, nameof(ValorTotal), "O valor pago é menor que o valor total.")
            );
        }

        public string IdPagamento { get; private set; }

        public DateTime DataPagamento { get; private set; }

        public DateTime DataExpiracao { get; private set; }

        /// <summary>
        /// Valor total.
        /// </summary>
        public decimal ValorTotal { get; private set; }

        /// <summary>
        /// Valor do pagamento.
        /// </summary>
        public decimal ValorPagamento { get; private set; }

        /// <summary>
        /// Quem irá realizar o pagamento.
        /// </summary>
        public string Proprietario { get; private set; }

        public Documento Documento { get; private set; }

        public Email Email { get; private set; }

        public Endereco Endereco { get; private set; }
    }
}
