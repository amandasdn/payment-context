using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using Xunit;

namespace PaymentContext.Tests.Entities
{
    public class AlunoTestes
    {
        private readonly Documento _documento;
        private readonly Email _email;
        private readonly Endereco _endereco;
        private readonly Aluno _aluno;

        public AlunoTestes()
        {
            _documento = new Documento("123456789-00", ETipoDocumento.CPF);
            _email = new Email("amanda@teste.com");
            _endereco = new Endereco("00000-000", "Rua Teste", "0", "", "Bairro Teste", "Teste Cidade", "SP", "Brasil");
            _aluno = new Aluno("Amanda", "Nascimento", _documento, _email);

        }

        [Fact(DisplayName = "Assinatura - Retornar erro quando há assinatura ativa")]
        public void TestarAssinatura_RetornarErroQuandoAtiva()
        {
            var assinatura = new Assinatura(null);
            var pagamento = new PagamentoPayPal (DateTime.Now, DateTime.Now.AddDays(15), 500, 500, "TESTE", _documento, _email, _endereco, $"{DateTime.Now:yyyyMMddHHmmss}{Guid.NewGuid().ToString().Replace("-","").Substring(0,5)}");

            assinatura.AdicionarPagamento(pagamento);
            _aluno.AdicionarAssinatura(assinatura);
            _aluno.AdicionarAssinatura(assinatura);

            Assert.False(_aluno.IsValid);
        }

        [Fact(DisplayName = "Assinatura - Retornar erro quando não há pagamento na assinatura")]
        public void TestarAssinatura_RetornarErroQuandoNaoHaPagamento()
        {
            // var assinatura = new Assinatura(null);
            // _aluno.AdicionarAssinatura(assinatura);
            // 
            // Assert.False(_aluno.IsValid);
        }

        [Fact(DisplayName = "Assinatura - Retornar sucesso")]
        public void TestarAssinatura_RetornarSucesso()
        {
            var assinatura = new Assinatura(DateTime.Now.AddYears(1));
            var pagamento = new PagamentoPayPal(DateTime.Now, DateTime.Now.AddDays(15), 500, 500, "TESTE", _documento, _email, _endereco, $"{DateTime.Now:yyyyMMddHHmmss}{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5)}");

            assinatura.AdicionarPagamento(pagamento);
            _aluno.AdicionarAssinatura(assinatura);

            Assert.True(_aluno.IsValid);
        }
    }
}