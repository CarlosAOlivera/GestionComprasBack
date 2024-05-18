using LionDev.Services;
using LionDev;
using LionDev.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;
        private readonly ILogger<UsuarioController> _logger;
        private string email;

        public UsuarioController(IConfiguration configuration,
                                 ApplicationDbContext context,
                                 IEmailService emailService,
                                 ILogger<UsuarioController> logger)
        {
            _configuration = configuration;
            _context = context;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<IActionResult> SendUserEmail(string userEmail)
        {
            await _emailService.SendEmailAsync(userEmail, "Subject", "Email body here");
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public dynamic Login([FromBody] Object optData)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());
            string correo = data.CorreoElectronico.ToString();
            string contrasena = data.Contrasena.ToString();

            try
            {
                var usuario = _context.Usuarios
                    .FirstOrDefault(u => u.CorreoElectronico == correo);

                if (usuario == null)
                {
                    return new
                    {
                        Status = "Error",
                        Message = "Usuario no encontrado."
                    };
                }

                if (usuario.Contrasena == contrasena)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, usuario.CorreoElectronico.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddHours(2),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    return new
                    {
                        Status = "Success",
                        Token = tokenString
                    };
                }
                else
                {
                    return new
                    {
                        Status = "Error",
                        Message = "Contraseña incorrecta."
                    };
                }
            }
            catch (Exception ex)
            {
                return new
                {
                    Status = "Error",
                    Message = "Ocurrió un error durante el inicio de sesión.",
                    Error = ex.Message
                };
            }
        }

        // PUT: Usuario/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(Guid id, Usuario Usuario)
        {
            if (id != Usuario.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(Usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: Usuario/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(Guid id)
        {
            var Usuario = await _context.Usuarios.FindAsync(id);
            if (Usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(Usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(Guid id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
