using LionDev.Models;

namespace LionDev.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string message);
        Task SendRegistrationConfirmationEmailAsync(string correoElectronico, object nombre, string confirmationToken, string? confirmationLink);
        Task SendPurchaseConfirmationEmailAsync(string email, string fullName, Orden orden);
    }
}
