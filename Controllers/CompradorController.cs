using LionDev;
using LionDev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Controllers 
{
    [ApiController]
    [Route("Comprador")]
    public class CompradorController : ControllerBase
    {
        public IConfiguration _configuration;
        private ApplicationDbContext _context;

        public CompradorController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
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
                Comprador comprador = _context.Compradores
                    .Where(x => x.CorreoElectronico == correo && x.Contrasena == contrasena)
                    .FirstOrDefault();

                //if (usuario == null)
                if (comprador == null)
                {
                    return new
                    {
                        success = false,
                        message = "Credenciales incorrectas",
                        result = ""
                    };
                }

                var jwt = _configuration.GetSection("Jwt")
                .Get<Jwt>();

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),                    
                    new Claim("id", comprador.IdComprador.ToString()),
                    new Claim("correo", comprador.CorreoElectronico)
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
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // GET: Comprador/Compradores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comprador>>> GetCompradores()
        {
            return await _context.Compradores.ToListAsync();
        }

        // GET: Comprador/Compradores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comprador>> GetComprador(Guid id)
        {
            var comprador = await _context.Compradores.FindAsync(id);

            if (comprador == null)
            {
                return NotFound();
            }

            return comprador;
        }

        // POST: Comprador/Guardar
        [HttpPost]
        [Route("Guardar")]
        public async Task<ActionResult<Comprador>> Guardar([FromBody] Comprador comprador)
        {
            try
            {
                comprador.IdComprador = new Guid();
                _context.Compradores.Add(comprador);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetComprador), new { id = comprador.IdComprador }, comprador);
            }
            catch (Exception ex)
            {                
                return BadRequest($"Error al crear el comprador: {ex.Message}");
            }
        }

        // PUT: Comprador/Compradores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComprador(Guid id, Comprador comprador)
        {
            if (id != comprador.IdComprador)
            {
                return BadRequest();
            }

            _context.Entry(comprador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompradorExists(id))
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

        // DELETE: Comprador/Compradores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComprador(Guid id)
        {
            var comprador = await _context.Compradores.FindAsync(id);
            if (comprador == null)
            {
                return NotFound();
            }

            _context.Compradores.Remove(comprador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompradorExists(Guid id)
        {
            return _context.Compradores.Any(e => e.IdComprador == id);
        }
    }
}
