using LionDev;
using LionDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{

    [ApiController]
    public class ProductoController : ControllerBase
    {
        //public IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public ProductoController(/*IConfiguration configuration*/ ApplicationDbContext context)
        {
            //_configuration = configuration;
            _context = context;
        }

        // GET: api/Producto/GetByName/{name}
        [HttpGet]
        [Route("api/v1/Producto/{name}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetByName(string name)
        {
            
            var productos = await _context.Productos
                            .Where(p => p.Nombre.Contains(name))
                            .ToListAsync();

            if (!productos.Any())
            {
                return NotFound("Productos no encontrados.");
            }

            return productos;
        }

        // GET: api/Producto/GetMasBuscados
        [HttpGet]
        [Route("api/Producto/GetMasBuscados")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetGetMasBuscados()
        {
            var productos = await _context.Productos
                            .Where(p => p.EsDeLosMasBuscados)
                            .ToListAsync();

            if (!productos.Any())
            {
                return NotFound("No hay productos más buscados.");
            }

            return productos;
        }

        // GET: Producto/GetBySexo/{paraSexo}
        [HttpGet]
        [Route("api/Producto/GetBySexo/{paraSexo}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetBySexo(string paraSexo)
        {
            var productos = await _context.Productos
                                .Where(p => p.ParaSexo.Equals(paraSexo, StringComparison.OrdinalIgnoreCase))
                                .ToListAsync();

            if (!productos.Any())
            {
                return NotFound($"No hay productos para el sexo especificado: {paraSexo}.");
            }

            return productos;
        }

        // GET: Producto/GetByMarca/{marca}
    }
}
