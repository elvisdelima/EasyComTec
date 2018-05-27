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
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}