using FruitEcommerce.ApplicationCore.Entities;
using FruitEcommerce.ApplicationCore.Interfaces.Repositories;
using FruitEcommerce.Infrastructure.Data;

namespace FruitEcommerce.Infrastructure.Repository
{
    public class FruitRepository : Repository<Fruit>, IFruitRepository
    {
        public FruitRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
