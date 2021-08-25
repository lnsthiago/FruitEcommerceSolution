using FruitEcommerce.ApplicationCore.Entities;
using FruitEcommerce.ApplicationCore.Interfaces.Repositories;
using FruitEcommerce.ApplicationCore.Interfaces.Services;
using System.Collections.Generic;

namespace FruitEcommerce.ApplicationCore.Services
{
    public class FruitService : IFruitService
    {
        private IFruitRepository _fruitRepository;

        public FruitService(IFruitRepository fruitRepository)
        {
            _fruitRepository = fruitRepository;
        }

        IEnumerable<Fruit> IFruitService.GetAll()
        {
            return _fruitRepository.GetAll();
        }

        public Fruit GetById(int id)
        {
            return _fruitRepository.GetById(id);
        }

        public void Update(Fruit fruit)
        {
            _fruitRepository.Update(fruit);
        }

        public Fruit Add(Fruit fruit)
        {
            return _fruitRepository.Add(fruit);
        }

        public void Remove(Fruit fruit)
        {
            _fruitRepository.Remove(fruit);
        }
    }
}
