using LionDev.Services;
using LionDev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Org.BouncyCastle.Crypto.Generators;

namespace LionDev.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;
        private readonly ILogger<UsuarioController> _logger;

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

        // POST: Usuario/Guardar
        [HttpPost]
        [Route("Guardar")]
        public async Task<ActionResult<Usuario>> Guardar([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Invalid user data.");
            }

            // Check if the email is already registered
            bool emailExists = await _context.Usuarios.AnyAsync(u => u.CorreoElectronico == usuario.CorreoElectronico);
            if (emailExists)
            {
                return BadRequest("Email already registered.");
            }

            // Hash the password
            usuario.Contrasena = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);

            // Set the registration date and time
            usuario.FechaRegistro = DateTime.UtcNow;

            try
            {
                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();
                return Ok(new { Status = "Success", Message = "Usuario registrado con éxito." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar el usuario");
                return StatusCode(500, "Ocurrió un error al registrar el usuario.");
            }
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

                // Verifica la contraseña hasheada
                bool validPassword = BCrypt.Net.BCrypt.Verify(contrasena, usuario.Contrasena);

                if (validPassword)
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
                        success = true,
                        message = "Login exitoso",
                        result = tokenString
                    };
                }
                else
                {
                    return new
                    {
                        Status = "Error",
                        Message = "Email o Password incorrecto."
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login");
                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }

        //Email Verification        
        [HttpGet]
        [Route("check-email")]
        public async Task<ActionResult<bool>> CheckEmail([FromQuery] string email)
        {
            var usuario = await _context.Usuarios
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.CorreoElectronico == email);

            return usuario != null;
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
