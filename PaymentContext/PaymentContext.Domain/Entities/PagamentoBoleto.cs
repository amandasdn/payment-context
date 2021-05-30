using PaymentContext.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                string documento,
                string email,
                string endereco,

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
