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
    [Route("[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public FruitsController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Buscar Frutas
        /// </summary>
        /// <response code="200">Retorna uma lista com todas as Frutas</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fruit>>> GetFruits()
        {
            return await _context.Fruits.ToListAsync();
        }

        /// <summary>
        /// Buscar Fruta pelo Id
        /// </summary>
        /// <response code="200">Retorna uma lista com todas as Frutas</response>
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

        /// <summary>
        /// Atualizar Fruta
        /// </summary>
        /// <response code="200">Retorna a fruta com os dados atualizados</response>
        /// <param name="fruit">Objeto Fruit com as informações para atualizar</param>
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

        /// <summary>
        /// Adicionar Fruta
        /// </summary>
        /// <response code="200">Retorna a fruta adicionada</response>
        /// <param name="fruit">Objeto Fruit com as informações para adicionar</param>
        [HttpPost]
        public async Task<ActionResult<Fruit>> PostFruit(Fruit fruit)
        {
            _context.Fruits.Add(fruit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFruit", new { id = fruit.FruitId }, fruit);
        }

        /// <summary>
        /// Deletar Fruta
        /// </summary>
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
