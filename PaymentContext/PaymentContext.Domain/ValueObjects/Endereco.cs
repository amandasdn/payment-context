using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Endereco : ObjetoValor
    {
        public Endereco(string cep, string logradouro, string numero, string complemento, string bairro, string cidade, string estado, string pais)
        {
            Cep = FormatarCEP(cep);
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        public string Cep { get; private set; }

        public string Logradouro { get; private set; }
        
        public string Numero { get; private set; }

        public string Complemento { get; private set; }

        public string Bairro { get; private set; }

        public string Cidade { get; private set; }

        public string Estado { get; private set; }

        public string Pais { get; private set; }

        private string FormatarCEP(string cep) => cep.Replace("-", "");
    }
}
