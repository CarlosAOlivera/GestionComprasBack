using LionDev.Models;
using System.Threading.Tasks;

namespace LionDev.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
        Task SendPurchaseConfirmationEmailAsync(string toEmail, string customerName, Orden orden);
        Task SendRegistrationConfirmationEmailAsync(string toEmail, string nombre, string confirmationToken, string confirmationLink);
    }
}
