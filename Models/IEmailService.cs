using LionDev.Models;

namespace LionDev.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
        Task SendRegistrationConfirmationEmailAsync(string toEmail, object nombre, string confirmationToken, string? confirmationLink);
        Task SendPurchaseConfirmationEmailAsync(string toEmail, string customerName, Orden orden);
        Task SendPurchaseConfirmationEmailAsync(object email, object fullName, Orden orden);
    }
}
