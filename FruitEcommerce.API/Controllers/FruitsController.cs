using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FruitEcommerce.ApplicationCore.Entities;
using FruitEcommerce.ApplicationCore.Interfaces.Services;

namespace FruitEcommerce.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        private IFruitService _fruitService;

        public FruitsController(IFruitService fruitService)
        {
            _fruitService = fruitService;
        }

        /// <summary>
        /// Buscar Frutas
        /// </summary>
        /// <response code="200">Retorna uma lista com todas as Frutas</response>
        [HttpGet]
        public ActionResult<IEnumerable<Fruit>> GetFruits()
        {
            return _fruitService.GetAll().ToList();
        }

        /// <summary>
        /// Buscar Fruta pelo Id
        /// </summary>
        /// <response code="200">Retorna a Fruta conforme o Id filtrado</response>
        [HttpGet("{id}")]
        public ActionResult<Fruit> GetFruit(int id)
        {
            var fruit = _fruitService.GetById(id);

            if (fruit == null)
                return NotFound();

            return fruit;
        }

        /// <summary>
        /// Atualizar Fruta
        /// </summary>
        /// <param name="fruit">Objeto Fruit com as informações para atualizar</param>
        [HttpPut("{id}")]
        public IActionResult PutFruit(int id, Fruit fruit)
        {
            if (id != fruit.FruitId)
                return BadRequest();

            try
            {
                var fruitToUpdate = _fruitService.GetById(id);
                if (fruitToUpdate == null)
                    return NotFound();                

                fruitToUpdate.UpdateProperties(fruit);
                _fruitService.Update(fruitToUpdate);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FruitExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Adicionar Fruta
        /// </summary>
        /// <response code="200">Retorna a fruta adicionada</response>
        /// <param name="fruit">Objeto Fruit com as informações para adicionar</param>
        [HttpPost]
        public ActionResult<Fruit> PostFruit(Fruit fruit)
        {
            fruit = _fruitService.Add(fruit);

            return CreatedAtAction("GetFruit", new { id = fruit.FruitId }, fruit);
        }

        /// <summary>
        /// Deletar Fruta
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteFruit(int id)
        {
            var fruit = _fruitService.GetById(id);
            if (fruit == null)
                return NotFound();

            _fruitService.Remove(fruit);

            return NoContent();
        }

        private bool FruitExists(int id)
        {
            var fruit = _fruitService.GetById(id);
            if (fruit == null)
                return false;
            return true;
        }
    }
}
