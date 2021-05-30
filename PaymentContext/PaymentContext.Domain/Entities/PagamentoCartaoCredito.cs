using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public class PagamentoCartaoCredito : Pagamento
    {
        public PagamentoCartaoCredito(
                DateTime dataPagamento,
                DateTime dataExpiracao,
                decimal valor,
                decimal valorPagamento,
                string proprietario,
                Documento documento,
                Email email,
                Endereco endereco,

                string titular,
                string numero,
                string ultimaTransacao
            )
            : base(dataPagamento, dataExpiracao, valor, valorPagamento, proprietario, documento, email, endereco)
        {
            Titular = titular;
            Numero = numero;
            UltimaTransacao = ultimaTransacao;
        }

        public string Titular { get; private set; }

        public string Numero { get; private set; }

        public string UltimaTransacao { get; private set; }
    }
}
