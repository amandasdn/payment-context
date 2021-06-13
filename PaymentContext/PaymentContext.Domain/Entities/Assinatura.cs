using Flunt.Validations;
using PaymentContext.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Assinatura : Entidade
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
            AddNotifications(new Contract<Pagamento>()
                .Requires()
                .IsLowerThan(pagamento.DataPagamento, DateTime.Now, nameof(pagamento.DataPagamento), "A data do pagamento deve ser futura.")
            );

            if(IsValid) _pagamentos.Add(pagamento);
        }
        
        public void AlterarStatusAssinatura(bool ativo)
        {
            Ativo = ativo;
            DataUltimaAtualizacao = DateTime.Now;
        }
    }
}
