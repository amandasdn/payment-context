using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Documento : ObjetoValor
    {
        public Documento(string numero, ETipoDocumento tipo)
        {
            Numero = FormatarNumero(numero);
            Tipo = tipo;

            AddNotifications(new Contract<Documento>()
                .Requires()
                .IsNotEmpty(Numero, nameof(Numero), "Necessário informar o número do documento.")
                .IsTrue(Valido(), nameof(Numero), "Documento inválido.")
            );
        }

        public string Numero { get; private set; }

        public ETipoDocumento Tipo { get; private set; }

        private bool Valido()
        {
            if (Tipo == ETipoDocumento.CNPJ && Numero.Length.Equals(14))
                return true;

            if (Tipo == ETipoDocumento.CPF && Numero.Length.Equals(11))
                return true;

            return false;
        }

        private string FormatarNumero(string numero) => numero.Replace("-", "").Replace("/", "");
    }
}
