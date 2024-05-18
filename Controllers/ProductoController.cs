using LionDev;
using LionDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/Producto/GetByName/{name}
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

        // GET: api/v1/Producto/GetMasBuscados
        [HttpGet("GetMasBuscados")]
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

        // GET: api/v1/Producto/GetBySexo/{paraSexo}
        [HttpGet("GetBySexo/{paraSexo}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetBySexo(string paraSexo)
        {
            var productos = await _context.Productos
                                .Where(p => p.ParaSexo == paraSexo)
                                .ToListAsync();

            if (!productos.Any())
            {
                return NotFound("No se encontraron productos para el género especificado.");
            }

            return productos;
        }

        // GET: api/v1/Producto/Search
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Producto>>> Search(string query)
        {
            var productos = await _context.Productos
                .Include(p => p.Marca) // Incluir la navegación de Marca
                .Where(p => (p.Descripcion != null && p.Descripcion.Contains(query)) ||
                            (p.Color != null && p.Color.Contains(query)) ||
                            (p.Marca != null && p.Marca.Nombre.Contains(query))) // Buscar en el nombre de la marca
                .ToListAsync();

            if (!productos.Any())
            {
                return NotFound("No se encontraron productos con esas características.");
            }

            return productos;
        }
    }
}
