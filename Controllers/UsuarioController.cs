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
                    success = true,
                    message = "Login exitoso",
                    result = new JwtSecurityTokenHandler().WriteToken(token)
                };

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
            }
        }


        // GET: Usuario/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: Usuario/GetUsuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(Guid id)
        {
            var Usuario = await _context.Usuarios.FindAsync(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Usuario;
        }

        [HttpGet]
        [Route("check-email")]
        public async Task<ActionResult<bool>> CheckEmail([FromQuery] string email)
        {
            var usuario = await _context.Usuarios
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.CorreoElectronico == email);

            return usuario != null;
        }

        // POST: Usuario/Guardar
        [HttpPost]
        [Route("Guardar")]
        public async Task<ActionResult<Usuario>> Guardar([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                usuario.EmailConfirmado = true;

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
            
            
                //Pending User Creation
                /* var pendingUsuario = new PendingUsuario
                 {
                     CorreoElectronico = usuario.CorreoElectronico,
                     ConfirmationToken = TokenGenerator.GenerateToken(),
                     EmailConfirmado = false,
                 };

                 //Adding Pending User to Database
                 _context.PendingUsuarios.Add(pendingUsuario);
                 await _context.SaveChangesAsync();

                 var confirmationLink = Url.Action(
                     nameof(ConfirmarCorreo),
                     "Usuario",
                     new { userId = pendingUsuario.Id, token = pendingUsuario.ConfirmationToken },
                     Request.Scheme);

                 await _emailService.SendRegistrationConfirmationEmailAsync(
                     pendingUsuario.CorreoElectronico,
                     usuario.Nombres, 
                     pendingUsuario.ConfirmationToken,
                     confirmationLink
                 );



                return Ok("Por favor, revisa tu correo electrónico para confirmar tu registro.");*/

                return Ok("Usuario registrado exitosamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar el usuario");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al guardar el usuario: {ex.Message}");
            }
        }

        private object ConfirmarCorrero()
        {
            throw new NotImplementedException();
        }

        // Email confirmation
       /* [HttpGet]
        [Route("ConfirmarCorreo")]
        public async Task<IActionResult> ConfirmarCorreo(Guid Id, string token)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var pendingUsuario = await _context.PendingUsuarios
                        .FirstOrDefaultAsync(pu => pu.Id == Id && pu.ConfirmationToken == token);

                    if (pendingUsuario != null)
                    {
                        var usuario = new Usuario
                        {
                            CorreoElectronico = pendingUsuario.CorreoElectronico,
                            EmailConfirmado = true,
                        };

                        _context.Usuarios.Add(usuario);
                        _context.PendingUsuarios.Remove(pendingUsuario);
                        await _context.SaveChangesAsync();

                        await transaction.CommitAsync();

                        return Ok("Correo electrónico confirmado con éxito.");
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        return BadRequest("No se pudo confirmar el correo electrónico.");
                    }
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error durante la confirmación del correo electrónico.");
                }
            }
        }*/

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
