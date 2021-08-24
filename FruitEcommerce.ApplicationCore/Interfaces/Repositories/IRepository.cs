using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FruitEcommerce.ApplicationCore.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> expression);
        void Remove(T entity);
    }
}
