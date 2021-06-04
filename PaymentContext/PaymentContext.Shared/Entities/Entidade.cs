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
    }
}
