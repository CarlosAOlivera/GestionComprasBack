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

            try
            {
                // Validar campos obligatorios de la orden
                if (string.IsNullOrEmpty(orden.CustomerEmail) || string.IsNullOrEmpty(orden.CustomerFirstName) || string.IsNullOrEmpty(orden.CustomerLastName))
                {
                    return BadRequest("Faltan campos obligatorios en la orden.");
                }

                // Guardar la orden en la base de datos
                _context.Ordenes.Add(orden);
                await _context.SaveChangesAsync();

                // Enviar correo de confirmación de la orden
                await _emailService.SendPurchaseConfirmationEmailAsync(orden.CustomerEmail, $"{orden.CustomerFirstName} {orden.CustomerLastName}", orden);

                return Ok(new { message = "Orden completada y email enviado.", ordenId = orden.OrdenId });
            }
            catch (Exception ex)
            {
                // Registro de la excepción para diagnósticos
                // Puedes usar un servicio de logging como Serilog, NLog, etc.
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
