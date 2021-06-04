using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ObjetoValor
    {
        public Email(string endereco)
        {
            Endereco = endereco;

            AddNotifications(new Contract<Email>()
                .Requires()
                .IsNotNullOrEmpty(Endereco, nameof(Endereco), "E-mail não foi preenchido.")
                .IsEmail(Endereco, nameof(Endereco), "E-mail inválido.")
            );
        }

        public string Endereco { get; set; }
    }
}
