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

            if (string.IsNullOrWhiteSpace(Nome))
                AddNotification(ObterPropriedade<Aluno>(nameof(Nome)), "Nome inválido.");

            if (string.IsNullOrWhiteSpace(Sobrenome))
                AddNotification(ObterPropriedade<Aluno>(nameof(Sobrenome)), "Sobrenome inválido.");
        }

        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public Documento Documento { get; private set; }

        public Email Email { get; private set; }

        public Endereco Endereco { get; private set; }

        public IReadOnlyCollection<Assinatura> Assinaturas { get { return _assinaturas.ToArray(); } }

        public void AdicionarAssinatura(Assinatura assinatura)
        {
            foreach (var a in Assinaturas)
                a.AlterarStatusAssinatura(false);

            _assinaturas.Add(assinatura);
        }
    }
}
