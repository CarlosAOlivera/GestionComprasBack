using LionDev.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

using System.Threading.Tasks;
using System.Linq;

namespace LionDev.Services
{
    public class SmtpEmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public SmtpEmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("co4100005@gmail.com", "jkew mhfj rzih jzac"),
                EnableSsl = true
            };

            using (client)
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("co4100005@gmail.com", "Fusion Desings"),
                    Subject = subject,
                    Body = content,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(toEmail);

                await client.SendMailAsync(mailMessage);
            }
        }

        public async Task SendPurchaseConfirmationEmailAsync(string toEmail, string customerName, Orden orden)
        {
            var subject = "Confirmación de tu compra en Fusion Desings";

            var content = $@"
            <html>
            <body>
                <h1>Gracias por tu compra, {customerName}!</h1>
                <p>Hemos recibido tu pedido #{orden.OrdenId} y está siendo procesado.</p>
                <h2>Resumen del Pedido:</h2>
                <ul>
                    {string.Join("", orden.OrdenItems.Select(item => $"<li>{item.Quantity} x {item.ProductName} - ${item.Price}</li>"))}
                </ul>
                <p>Total: ${orden.Total}</p>
                <p>Fecha estimada de entrega: {orden.EstimatedDeliveryDate.ToShortDateString()}</p>
                <p>Si tienes preguntas sobre tu pedido, no dudes en contactarnos en www.fusion-designs.net</p>
                <p> Gracias por elegirnos,</p>
                <p> Fusion Desings </p>
            </body>
            </html>";

            await SendEmailAsync(toEmail, subject, content);
        }

        public Task SendRegistrationConfirmationEmailAsync(string toEmail, string nombre, string confirmationToken, string? confirmationLink)
        {
            throw new NotImplementedException("Este método no está implementado.");
        }
    }
}
