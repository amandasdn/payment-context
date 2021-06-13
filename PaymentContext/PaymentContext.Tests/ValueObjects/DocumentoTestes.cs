using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Tests.ValueObjects
{
    public class DocumentoTestes
    {
        [Fact(DisplayName = "CPF - Retornar erro quando inválido")]
        public void TestarCPF_RetornarErroQuandoInvalido()
        {
            var doc = new Documento("123", ETipoDocumento.CPF);

            Assert.NotNull(doc);
            Assert.False(doc.IsValid);
        }

        [Fact(DisplayName = "CPF - Retornar sucesso quando válido")]
        public void TestarCPF_RetornarSucessoQuandoValido()
        {
            var cpf = "123456789-00";
            var doc = new Documento(cpf, ETipoDocumento.CPF);

            Assert.NotNull(doc);
            Assert.True(doc.IsValid);
        }

        [Fact(DisplayName = "CNPJ - Retornar erro quando inválido")]
        public void TestarCNPJ_RetornarErroQuandoInvalido()
        {
            var doc = new Documento("123", ETipoDocumento.CNPJ);

            Assert.NotNull(doc);
            Assert.False(doc.IsValid);
        }

        [Fact(DisplayName = "CNPJ - Retornar sucesso quando válido")]
        public void TestarCNPJ_RetornarSucessoQuandoValido()
        {
            var cnpj = "12345678/0001-00";
            var doc = new Documento(cnpj, ETipoDocumento.CNPJ);

            Assert.NotNull(doc);
            Assert.True(doc.IsValid);
        }
    }
}
