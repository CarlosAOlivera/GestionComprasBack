using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Options;
using LionDev.Configurations;

namespace LionDev.Services
{
    public class SendGridEmailService : IEmailService
    {
        private readonly SendGridSettings _sendGridSettings;

        public SendGridEmailService(IOptions<SendGridSettings> sendGridSettings)
        {
            _sendGridSettings = sendGridSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var client = new SendGridClient(_sendGridSettings.ApiKey);
            var from = new EmailAddress("noreply@fashionnovax.com", "Fashion Nova X");
            var to = new EmailAddress(toEmail);
            var plainTextContent = "¡Gracias por registrarte en Fashion Nova X! Comienza a explorar lo último en moda con nosotros.";
            var htmlContent = $@"
                <html>
                    <body>
                        <h1>¡Bienvenido a Nuestra Tienda Online!</h1>
                        <p><strong>Gracias por registrarte.</strong></p>
                        <p>Descubre las últimas tendencias de moda y encuentra tu estilo perfecto. ¡Tu próxima gran compra te espera!</p>
                        <p>Visita nuestro <a href='https://www.fashionnovax.com'>sitio web</a> y comienza tu aventura de moda con nosotros.</p>
                    </body>
                </html>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}