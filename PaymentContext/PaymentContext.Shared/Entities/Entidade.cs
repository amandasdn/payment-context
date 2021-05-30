using Flunt.Notifications;
using System;

namespace PaymentContext.Shared.Entities
{
    public abstract class Entidade : Notifiable<Notification>
    {
        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        /// <summary>
        /// Obtém o nome da entidade + propriedade.
        /// </summary>
        public string ObterPropriedade<T>(string propriedade) => $"{typeof(T)}.{propriedade}";
    }
}
