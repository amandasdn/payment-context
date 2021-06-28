using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PaymentContext.Tests.Queries
{
    public class AlunoQueriesTestes
    {
        IList<Aluno> _alunos;

        public AlunoQueriesTestes()
        {
            _alunos = new List<Aluno>();

            for (var i = 0; i <= 5; i++)
            {
                _alunos.Add(
                    new Aluno("Aluno", i.ToString(), new Documento($"0000000000{i}", ETipoDocumento.CPF), new Email($"aluno{i}@teste.com"))
                );
            }
        }

        [Fact(DisplayName = "Aluno Queries - Retornar false se documento não existe")]
        public void TestarAlunoQueries_RetornarFalsoQuandoDocumentoNaoExiste()
        {
            // Arrange
            var exp = AlunoQueries.GetAluno("12345678910");

            // Act
            var aluno = _alunos.AsQueryable().Where(exp).FirstOrDefault();

            // Assert
            Assert.Null(aluno);
        }

        [Fact(DisplayName = "Aluno Queries - Retornar true se documento existe")]
        public void TestarAlunoQueries_RetornarVerdadeiroQuandoDocumentoExiste()
        {
            // Arrange
            var exp = AlunoQueries.GetAluno("00000000000");

            // Act
            var aluno = _alunos.AsQueryable().Where(exp).FirstOrDefault();

            // Assert
            Assert.NotNull(aluno);
        }
    }
}
