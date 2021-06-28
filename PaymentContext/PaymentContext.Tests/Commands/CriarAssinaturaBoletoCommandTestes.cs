using PaymentContext.Domain.Commands;
using Xunit;

namespace PaymentContext.Tests.Commands
{
    public class CriarAssinaturaBoletoCommandTestes
    {
        [Fact(DisplayName = "Command - Assinatura Boleto - Retorna erro quando nome inválido.")]
        public void TestarCommand_AssinaturaBoleto_QuandoNomeInvalido()
        {
            var command = new CriarAssinaturaBoletoCommand
            {
                Nome = ""
            };

            command.Validar();

            Assert.False(command.IsValid);
        }
    }
}
