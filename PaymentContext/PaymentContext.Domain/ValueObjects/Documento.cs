using Flunt.Validations;
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

            AddNotifications(new Contract<Documento>()
                .Requires()
                .IsTrue(Valido(), "Document.Number", "Documento inválido")
            );
        }

        public string Numero { get; set; }

        public ETipoDocumento Tipo { get; set; }

        private bool Valido()
        {
            if (Tipo == ETipoDocumento.CNPJ && Numero.Length.Equals(14))
                return true;

            if (Tipo == ETipoDocumento.CPF && Numero.Length.Equals(11))
                return true;

            return false;
        }
    }
}
