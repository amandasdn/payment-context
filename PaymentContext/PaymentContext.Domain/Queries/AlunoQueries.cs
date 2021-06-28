using PaymentContext.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace PaymentContext.Domain.Queries
{
    public static class AlunoQueries
    {
        public static Expression<Func<Aluno, bool>> GetAluno(string documento)
        {
            return x => x.Documento.Numero == documento;
        }
    }
}
