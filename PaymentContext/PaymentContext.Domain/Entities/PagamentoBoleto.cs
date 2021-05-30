using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Domain
{
    public class PagamentoBoleto : Pagamento
    {
        public PagamentoBoleto(
                DateTime dataPagamento,
                DateTime dataExpiracao,
                decimal valor,
                decimal valorPagamento,
                string proprietario,
                Documento documento,
                Email email,
                Endereco endereco,

                string codigoBarras,
                string numero
            )
            : base(dataPagamento, dataExpiracao, valor, valorPagamento, proprietario, documento, email, endereco)
        {
            CodigoBarras = codigoBarras;
            Numero = numero;
        }

        public string CodigoBarras { get; private set; }

        public string Numero { get; private set; }
    }
}
