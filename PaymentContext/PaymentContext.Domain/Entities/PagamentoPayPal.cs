using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public class PagamentoPayPal : Pagamento
    {
        public PagamentoPayPal(
                DateTime dataPagamento,
                DateTime dataExpiracao,
                decimal valor,
                decimal valorPagamento,
                string proprietario,
                Documento documento,
                Email email,
                Endereco endereco,

                string codigoTransacao
            )
            : base(dataPagamento, dataExpiracao, valor, valorPagamento, proprietario, documento, email, endereco)
        {
            CodigoTransacao = codigoTransacao;
        }

        public string CodigoTransacao { get; private set; }
    }
}
