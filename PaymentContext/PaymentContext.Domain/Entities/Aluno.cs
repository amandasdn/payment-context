using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Aluno : Entidade
    {
        private IList<Assinatura> _assinaturas;

        public Aluno(string nome, string sobrenome, Documento documento, Email email)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Documento = documento;
            Email = email;

            _assinaturas = new List<Assinatura>();

            AddNotifications(new Contract<Aluno>()
                .Requires()
                .IsNotNullOrEmpty(Nome, nameof(Nome), "Nome não foi preenchido.")
                .IsNotNullOrEmpty(Sobrenome, nameof(Sobrenome), "Sobrenome não foi preenchido.")
            );
        }

        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public Documento Documento { get; private set; }

        public Email Email { get; private set; }

        public Endereco Endereco { get; private set; }

        public IReadOnlyCollection<Assinatura> Assinaturas { get { return _assinaturas.ToArray(); } }

        public void AdicionarAssinatura(Assinatura assinatura)
        {
            var possuiAssinatura = false;

            foreach (var a in _assinaturas)
                if (a.Ativo)
                    possuiAssinatura = true;

            // Opção 1:
            AddNotifications(new Contract<Aluno>()
                .Requires()
                .IsFalse(possuiAssinatura, nameof(Assinaturas), "Este aluno já possui uma assinatura ativa.")
                .AreNotEquals(0, assinatura.Pagamentos.Count, $"{nameof(Assinaturas)}.{nameof(Pagamento)}", "Esta assinatura não possui pagamentos")
            );

            // Opção 2:
            // if (possuiAssinatura)
            //     AddNotification(nameof(Assinaturas), "Este aluno já possui uma assinatura ativa.");

            foreach (var a in Assinaturas)
                a.AlterarStatusAssinatura(false);

            _assinaturas.Add(assinatura);
        }
    }
}
