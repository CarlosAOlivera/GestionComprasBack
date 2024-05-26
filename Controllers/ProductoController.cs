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

<<<<<<< HEAD
        public ProductoController(/*IConfiguration configuration*/ ApplicationDbContext context) =>
            //_configuration = configuration;
=======
        public ProductoController(ApplicationDbContext context)
        {
>>>>>>> main
            _context = context;

<<<<<<< HEAD
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

=======
>>>>>>> main
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
                    .Where(p => p.ParaSexo.ToLower() == paraSexo.ToLower())
                    .ToListAsync();

            if (!productos.Any())
            {
                return NotFound($"No hay productos para el sexo especificado: {paraSexo}.");
            }

            return productos;
        }

        //Método de búsqueda general.
        [HttpGet("Search")]
        public async Task <ActionResult<IEnumerable<Producto>>> GeneralSearch(string query)
        {
            var criteria = ParseSearchQuery(query);
            var queryable = _context.Productos.AsQueryable();
            queryable = queryable.Where(p => p.Nombre.Contains(query) ||
                                             p.Descripcion.Contains(query) ||
                                             p.Color.Contains(query) ||
                                             p.Talla.Contains(query));

            var productos = await queryable.ToListAsync();
            return productos.Any() ? Ok(productos) : NotFound("No se encontraron productos con esas caracteristicas.");
        }

        //Método auxiliar
        private SearchCriteria ParseSearchQuery(string query)
        {
            var criteria = new SearchCriteria();
            foreach (var part in query.Split(' ')) 
            {
                if (IsColor(part)) criteria.Color = part;
                else if (IsSize(part)) criteria.Talla = part;
                else if (IsDescriptionKeyword(part)) criteria.Descripcion += part + " , ";
                else criteria.Name += part + " ";
            }
            return criteria;
        }

        private bool IsColor(string token)
        {
            var colors = new HashSet<string> { "rojo", "azul", "verde", "amarillo" };
            return colors.Contains(token.ToLower());
        }

        private bool IsSize(string token)
        {
            var sizes = new HashSet<string> { "XS", "S", "M", "L", "XL", "XXL" };
            return sizes.Contains(token.ToUpper());
        }

        private bool IsDescriptionKeyword(string token)
        {
            var descriptionKeywords = new HashSet<string> { "algodon", "impermeable", "transpirable", "fuerte" };
            return descriptionKeywords.Contains(token.ToLower());
        }


        
    }
}
