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
        [HttpGet("GetByName/{name}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetByName(string name)
        {
            var productos = await _context.Productos
                .Where(p => p.Nombre.Contains(name))
                .ToListAsync();

            if (!productos.Any())
            {
                return NotFound("Productos no encontrados.");
            }

            return Ok(productos);
        }

        // GET: api/v1/Producto/GetMasBuscados
        [HttpGet("GetMasBuscados")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetMasBuscados()
        {
            var productos = await _context.Productos
                .Where(p => p.EsDeLosMasBuscados)
                .ToListAsync();

            if (!productos.Any())
            {
                return NotFound("No hay productos más buscados.");
            }

            return Ok(productos);
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

            return Ok(productos);
        }

        // GET: api/v1/Producto/Search
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Producto>>> GeneralSearch(string query)
        {
            /*var criteria = ParseSearchQuery(query);
            var queryable = _context.Productos.AsQueryable();

            if (!string.IsNullOrEmpty(criteria.Name))
                queryable = queryable.Where(p => p.Nombre.Contains(criteria.Name));

            if (!string.IsNullOrEmpty(criteria.Descripcion))
                queryable = queryable.Where(p => p.Descripcion.Contains(criteria.Descripcion));

            if (!string.IsNullOrEmpty(criteria.Color))
                queryable = queryable.Where(p => p.Color.Contains(criteria.Color));

            if (!string.IsNullOrEmpty(criteria.Talla))
                queryable = queryable.Where(p => p.Talla.Contains(criteria.Talla));*/

            var queryable = _context.Productos.AsQueryable();

            foreach (var term in query.Split(' '))
            {
                var lowerTerm = term.ToLower();
                queryable = queryable.Where(p => p.Nombre.Contains(term) ||
                                                 p.Descripcion.Contains(term) ||
                                                 p.Color.Contains(term) ||
                                                 p.Talla.Contains(term));
            }

            var productos = await queryable.ToListAsync();

            if (!productos.Any())
            {
                return NotFound("No se encontraron productos con esas caracteristicas.");
            }

            return Ok(productos);
        }

        //Método auxiliar
        private SearchCriteria ParseSearchQuery(string query)
        {
            var criteria = new SearchCriteria();
            foreach (var part in query.Split(' '))
            {
                if (IsColor(part))
                    criteria.Color = part;
                else if (IsSize(part))
                    criteria.Talla = part;
                else if (IsDescriptionKeyword(part))
                    criteria.Descripcion += part + " , ";
                else
                    criteria.Name += part + " ";
            }

            // Trim trailing commas and spaces
            criteria.Descripcion = criteria.Descripcion?.Trim(' ', ',');
            criteria.Name = criteria.Name?.Trim();

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
