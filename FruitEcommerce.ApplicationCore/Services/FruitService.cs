using FruitEcommerce.ApplicationCore.Interfaces.Repositories;
using FruitEcommerce.ApplicationCore.Interfaces.Services;

namespace FruitEcommerce.ApplicationCore.Services
{
    public class FruitService : IFruitService
    {
        private IFruitRepository _fruitRepository;

        public FruitService(IFruitRepository fruitRepository)
        {
            _fruitRepository = fruitRepository;
        }
    }
}
