using LionDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LionDev.Services;
using System.Threading.Tasks;

namespace LionDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ApplicationDbContext _context;

        public OrdenController(IEmailService emailService, ApplicationDbContext context)
        {
            _emailService = emailService;
            _context = context;
        }

        [HttpPost]
        [Route("confirm")]
        public async Task<IActionResult> ConfirmOrder([FromBody] Orden orden)
        {
            // Lógica para procesar la orden
            // Por ejemplo, guardar la orden en la base de datos, etc.

            // Enviar correo electrónico de confirmación
            await _emailService.SendPurchaseConfirmationEmailAsync(
                orden.Customer.Email,
                orden.Customer.FullName,
                orden
            );

            return Ok(new { message = "Orden confirmada y email enviado" });
        }
    }
}
