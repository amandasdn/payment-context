using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Repositories
{
    public interface IAlunoRepository
    {
        bool DocumentoExiste(string documento);

        bool EmailExiste(string email);

        void CriarAssinatura(Aluno aluno);
    }
}
