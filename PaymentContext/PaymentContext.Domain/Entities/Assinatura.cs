using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class Assinatura
    {
        private IList<Pagamento> _pagamentos;

        public Assinatura(DateTime? dataExpiracao)
        {
            Ativo = true;
            DataInicio = DateTime.Now;
            DataUltimaAtualizacao = DateTime.Now;
            DataExpiracao = dataExpiracao;

            _pagamentos = new List<Pagamento>();
        }

        public bool Ativo { get; set;  }

        public DateTime DataInicio { get; set; }

        public DateTime DataUltimaAtualizacao { get; set; }

        public DateTime? DataExpiracao { get; set; }

        public IReadOnlyCollection<Pagamento> Pagamentos { get { return _pagamentos.ToList(); } }

        public void AdicionarPagamento(Pagamento pagamento)
        {
            _pagamentos.Add(pagamento);
        }
        
        public void AlterarStatusAssinatura(bool ativo)
        {
            Ativo = ativo;
            DataUltimaAtualizacao = DateTime.Now;
        }
    }
}
