using LionDev.Models;
using LionDev.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LionDev.Services
{
    public class SmtpEmailService: IEmailService
    {
        //Email Confirmation
        public async Task SendRegistrationConfirmationEmailAsync(string correoElectronico, object nombre, string confirmationToken, string? confirmationLink)
        {
            var subject = "Confirma tu Registro";
            //var frontEndUrl = "http://localhost:4200"; 
            //var confirmationLink = $"{frontEndUrl}/confirmar-correo?token={token}";

            var content = $@"
            <html>
            <body>
                <p>Saludos {nombre},</p>
                <p>Gracias por registrarte con nosotros. Por favor confirma tu email al presionar el siguiente enlace:</p>
                <p><a href='{confirmationLink}'>Confirma tu cuenta</a></p>
            </body>
            </html>";

            await SendEmailAsync(correoElectronico, subject, content);
        }

        //General method for sending email
        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("co4100005@gmail.com", "jkew mhfj rzih jzac");
                client.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("co4100005@gmail.com"),
                    Subject = subject,
                    Body = content,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(toEmail);

                await client.SendMailAsync(mailMessage);
            }
        }

        public Task SendPurchaseConfirmationEmailAsync(string email, string fullName, Orden orden)
        {
            throw new NotImplementedException();
        }
    }
}
