using LionDev;
using LionDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [Authorize(Roles = RolAdmin)] // Restringir acceso al rol de administrador
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private const string RolAdmin = "Administrador";

        public ProductoController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet("GetByName/{name}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("El nombre no puede ser nulo o vacío.");
            }

            var productos = await _context.Productos
                .Where(p => p.Nombre.Contains(name))
                .ToListAsync();

            if (productos == null || !productos.Any())
            {
                return NotFound("Productos no encontrados.");
            }

            return Ok(productos);
        }

        [HttpGet("GetMasBuscados")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetMasBuscados()
        {
            var productos = await _context.Productos
                .Where(p => p.EsDeLosMasBuscados)
                .ToListAsync();

            if (productos == null || !productos.Any())
            {
                return NotFound("No hay productos más buscados.");
            }

            return Ok(productos);
        }

        [HttpGet("GetBySexo/{paraSexo}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetBySexo(string paraSexo)
        {
            if (string.IsNullOrEmpty(paraSexo))
            {
                return BadRequest("El parámetro 'paraSexo' no puede ser nulo o vacío.");
            }

            var productos = await _context.Productos
                .Where(p => p.ParaSexo.ToLower() == paraSexo.ToLower())
                .ToListAsync();

            if (productos == null || !productos.Any())
            {
                return NotFound($"No hay productos para el sexo especificado: {paraSexo}.");
            }

            return Ok(productos);
        }

        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Producto>>> GeneralSearch(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest("La consulta no puede ser nula o vacía.");
            }

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

            if (productos == null || !productos.Any())
            {
                return NotFound("No se encontraron productos con esas características.");
            }

            return Ok(productos);
        }

        // Métodos auxiliares
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
