using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FruitEcommerce.ApplicationCore.Entities;
using FruitEcommerce.Infrastructure.Data;

namespace FruitEcommerce.API.Controllers
{
    [Route("api/[contro ller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public FruitsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Fruits1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fruit>>> GetFruits()
        {
            return await _context.Fruits.ToListAsync();
        }

        // GET: api/Fruits1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fruit>> GetFruit(int id)
        {
            var fruit = await _context.Fruits.FindAsync(id);

            if (fruit == null)
            {
                return NotFound();
            }

            return fruit;
        }

        // PUT: api/Fruits1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFruit(int id, Fruit fruit)
        {
            if (id != fruit.FruitId)
            {
                return BadRequest();
            }

            _context.Entry(fruit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FruitExists(id))
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

        // POST: api/Fruits1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fruit>> PostFruit(Fruit fruit)
        {
            _context.Fruits.Add(fruit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFruit", new { id = fruit.FruitId }, fruit);
        }

        // DELETE: api/Fruits1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFruit(int id)
        {
            var fruit = await _context.Fruits.FindAsync(id);
            if (fruit == null)
            {
                return NotFound();
            }

            _context.Fruits.Remove(fruit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FruitExists(int id)
        {
            return _context.Fruits.Any(e => e.FruitId == id);
        }
    }
}
