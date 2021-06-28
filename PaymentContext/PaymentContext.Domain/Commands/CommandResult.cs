using PaymentContext.Shared.Commands;
using System;

namespace PaymentContext.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {
            Data = DateTime.Now;
        }

        public CommandResult(bool sucesso, string mensagem)
        {
            Data = DateTime.Now;
            Sucesso = sucesso;
            Mensagem = mensagem;
        }

        public DateTime Data { get; set; }

        public bool Sucesso { get; set; }

        public string Mensagem { get; set; }
    }
}
