using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Documento : ObjetoValor
    {
        public Documento(string numero, ETipoDocumento tipo)
        {
            Numero = numero;
            Tipo = tipo;
        }

        public string Numero { get; set; }

        public ETipoDocumento Tipo { get; set; }
    }
}
