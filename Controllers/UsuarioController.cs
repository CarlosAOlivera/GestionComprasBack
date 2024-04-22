using LionDev;
using LionDev.Models;
using LionDev.Services;
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
        public IConfiguration _configuration;
        private ApplicationDbContext _context;
        private IEmailService _emailService;

        public UsuarioController(IConfiguration configuration, ApplicationDbContext context, IEmailService emailService)
        {
            _configuration = configuration;
            _context = context;
            _emailService = emailService;
        }


        [HttpPost]
        [Route("Login")]
        public dynamic Login([FromBody] Object optData)

        //public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
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
                        success = false,
                        message = "Usuario no registrado"
                    };
                }

                var hasher = new PasswordHasher<Usuario>();
                var result = hasher.VerifyHashedPassword(usuario, usuario.Contrasena, contrasena);

                if (result != PasswordVerificationResult.Success)
                {
                    return new
                    {
                        success = false,
                        message = "Credenciales incorrectas"
                    };
                }

                var jwt = _configuration.GetSection("Jwt")
                .Get<Jwt>();

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("id", usuario.IdUsuario.ToString()),
                    new Claim("correo", usuario.CorreoElectronico)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                var singIng = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: singIng
                );

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
            try
            {
                usuario.IdUsuario = Guid.NewGuid();

                var hasher = new PasswordHasher<Usuario>();

                usuario.Contrasena = hasher.HashPassword(usuario, usuario.Contrasena);
                
                usuario.EmailConfirmado = false;

                var token = TokenGenerator.GenerateToken();
                usuario.ConfirmationToken = token;

                var confirmationLink = Url.Action(
                    nameof(ConfirmarCorreo),
                    "Usuario",
                    new { userId = usuario.IdUsuario, token = token },
                    Request.Scheme);
                await _emailService.SendEmailAsync(usuario.CorreoElectronico, "Confirmar correo electrónico", $"Por favor confirma tu correo electrónico haciendo clic en el siguiente enlace: <a href='{confirmationLink}'>Confirmar correo electrónico</a>");

                return Ok("Por favor, revisa tu correo electrónico para confirmar tu registro.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el Usuario: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("ConfirmarCorreo")]
        public async Task<IActionResult> ConfirmarCorreo(Guid userId, string token)
        {
            var usuario = await _context.Usuarios.FindAsync(userId);
            if (usuario != null && usuario.ConfirmationToken == token)
            {
                usuario.EmailConfirmado = true;
                usuario.ConfirmationToken = null;
                await _context.SaveChangesAsync();

                return Ok("Correo electrónico confirmado con éxito.");
            }
            else{
                return BadRequest("No se pudo confirmar el correo electrónico.");
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