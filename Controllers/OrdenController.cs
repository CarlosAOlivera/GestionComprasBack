using LionDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LionDev.Services;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;

namespace LionDev.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;

        public OrdenController(IEmailService emailService, ApplicationDbContext context)
        {
            _context = context;
            _emailService = emailService;
        }

        [HttpPost("complete-order")]
        public async Task<IActionResult> CompleteOrder([FromBody] Orden orden)
        {
            if (orden == null)
            {
                return BadRequest("Orden no puede ser nula.");
            }

            _context.Ordenes.Add(orden);
            await _context.SaveChangesAsync();

            var subject = "Confirmación de Orden";
            var content = $"Gracias por tu compra. Tu orden con ID {orden.OrdenId} ha sido recibida.";

            await _emailService.SendEmailAsync(orden.Email, subject, content);

            return Ok(new { message = "Orden completada y email enviado.", ordenId = orden.OrdenId });
        }
    }
}
