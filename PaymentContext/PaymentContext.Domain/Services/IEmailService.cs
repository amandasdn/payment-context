namespace PaymentContext.Domain.Services
{
    public interface IEmailService
    {
        void EnviarEmail(string destinatario, string email, string assunto, string conteudo);
    }
}
