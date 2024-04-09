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
    [Route("Usuario")]

    //public class LoginDto
    /*{
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
    }*/
    public class UsuarioController : ControllerBase
    {
        public IConfiguration _configuration;
        private ApplicationDbContext _context;

        public UsuarioController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
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
                /*var usuario = await _context.Usuarios
                    .AsNoTracking()
                    .SingleOrDefaultAsync(u => u.CorreoElectronico == loginDto.CorreoElectronico);

                if (usuario == null)
                {
                    return BadRequest(new { success = false, message = "Credenciales incorrectas" });
                }

                var hasher = new PasswordHasher<Usuario>();
                var verificationResult = hasher.VerifyHashedPassword(usuario, usuario.Contrasena, loginDto.Contrasena);

                if (verificationResult == PasswordVerificationResult.Failed)
                {
                    return BadRequest(new { success = false, message = "Credenciales incorrectas" });
                }*/

                Usuario Usuario = _context.Usuarios
                    .Where(x => x.CorreoElectronico == correo && x.Contrasena == contrasena)
                    .FirstOrDefault();

                if (Usuario == null)
                {
                    /*var result = hasher.VerifyHashedPassword(usuario, usuario.Contrasena, contrasena);

                    if (result == PasswordVerificationResult.Failed)
                    {
                        return new
                        {
                            success = false,
                            message = "Credenciales incorrectas",
                            result = ""
                        };
                    }*/

                    return new
                    {
                        success = false,
                        message = "Credenciales incorrectas",
                        reult = ""
                    };
                }
                    var jwt = _configuration.GetSection("Jwt")
                    .Get<Jwt>();

                    var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("id", Usuario.IdUsuario.ToString()),
                    new Claim("correo", Usuario.CorreoElectronico)
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
                        message = "exito",
                        result = new JwtSecurityTokenHandler().WriteToken(token)
                    };


                    /*var jwtToken = GenerateJwtToken(usuario);

                    return Ok(new
                    {
                        success = true,
                        message = "Éxito",
                        token = jwtToken
                    });*/
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    
        /*private string GenerateJwtToken(Usuario usuario)
        {
            var jwt = _configuration.GetSection("Jwt")
               .Get<Jwt>();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwtSetting.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")),                    
                new Claim("id", usuario.IdUsuario.ToString()),
                new Claim("correo", usuario.CorreoElectronico)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var singIngCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: jwtSettings.Issuer,
                    audience: jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: singIngCred
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }*/


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

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                usuario.Contrasena = string.Empty;

                return CreatedAtAction(nameof(GetUsuario), new { id = usuario.IdUsuario }, usuario);
            }
            catch (Exception ex)
            {                
                return BadRequest($"Error al crear el Usuario: {ex.Message}");
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
