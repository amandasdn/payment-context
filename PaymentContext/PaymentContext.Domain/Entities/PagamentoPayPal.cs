using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                string documento,
                string email,
                string endereco, 

                string codigoTransacao
            )
            : base(dataPagamento, dataExpiracao, valor, valorPagamento, proprietario, documento, email, endereco)
        {
            CodigoTransacao = codigoTransacao;
        }

        public string CodigoTransacao { get; private set; }
    }
}
