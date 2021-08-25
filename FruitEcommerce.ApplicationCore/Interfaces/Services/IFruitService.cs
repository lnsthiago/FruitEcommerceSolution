using FruitEcommerce.ApplicationCore.Entities;
using System.Collections.Generic;

namespace FruitEcommerce.ApplicationCore.Interfaces.Services
{
    public interface IFruitService
    {
        IEnumerable<Fruit> GetAll();
        Fruit GetById(int id);
        void Update(Fruit fruit);
        Fruit Add(Fruit fruit);
        void Remove(Fruit fruit);
    }
}
