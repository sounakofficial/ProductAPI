using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("[action]")]
    [ApiController]
    //[Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly ProductAPIContext _context;

        public ProductsController(ProductAPIContext context)
        {
            _context = context;
        }

        // GET: /searchProductById/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> searchProductById(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET: /searchProductByName/toy
        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Product>>> searchProductByName(string name)
        {
            var product = await _context.Product.Where(x => x.Name == name).ToListAsync();

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}/{rating}")]
        public async Task<IActionResult> addProductRating(int id, int rating)
        {
            if (!(rating > 0 && rating <= 5))
            {
                return BadRequest();
            }
            Product p = await _context.Product.FindAsync(id);
            if (p == null)
            {
                return BadRequest();
            }

            p.Rating = rating;

            _context.Entry(p).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}