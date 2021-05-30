using PaymentContext.Domain.Entities;
using System;
using Xunit;

namespace PaymentContext.Tests
{
    public class AlunoTestes
    {
        [Fact]
        public void AdicionarAssinatura()
        {
            var assinatura = new Assinatura(DateTime.Now.AddDays(30));
            var aluno = new Aluno("Amanda", "Nascimento", "0000000000", "amanda@teste.com");

            aluno.AdicionarAssinatura(assinatura);
        }
    }
}
