using LionDev.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LionDev.Services
{
    public class SmtpEmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public SmtpEmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string content, bool useDefaultCredentials = false)
        {
            SmtpClient client;
            if (useDefaultCredentials)
            {
                client = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("co4100005@gmail.com", "jkew mhfj rzih jzac"),
                    EnableSsl = true
                };
            }
            else
            {
                client = new SmtpClient(_emailSettings.MailServer, _emailSettings.MailPort)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_emailSettings.Sender, _emailSettings.Password),
                    EnableSsl = true
                };
            }

            using (client)
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(useDefaultCredentials ? "co4100005@gmail.com" : _emailSettings.Sender),
                    Subject = subject,
                    Body = content,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(toEmail);

                await client.SendMailAsync(mailMessage);
            }
        }

        public Task SendEmailAsync(string toEmail, string subject, string content)
        {
            throw new NotImplementedException();
        }

        public async Task SendPurchaseConfirmationEmailAsync(string toEmail, string customerName, Orden orden)
        {
            var subject = "Confirmación de tu compra en [Nombre de la Tienda]";

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
                <p>Si tienes preguntas sobre tu pedido, no dudes en contactarnos a [tu-email-de-contacto].</p>
                <p>Gracias por elegirnos,</p>
                <p>[Nombre de la Tienda]</p>
            </body>
            </html>";

            await SendEmailAsync(toEmail, subject, content);
        }


        public Task SendRegistrationConfirmationEmailAsync(string toEmail, object nombre, string confirmationToken, string? confirmationLink)
        {
            throw new NotImplementedException();
        }
    }
}
