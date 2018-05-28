using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain;

namespace Infrastructure.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        T Get(Guid id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Update(T entity);
        void Delete(Guid id);
    }
}