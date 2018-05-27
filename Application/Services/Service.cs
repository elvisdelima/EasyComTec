using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Interfaces;
using Domain;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class Service<T> : IService<T> where T : Entity
    {
        protected Service(IRepository<T> repository)
        {
            Repository = repository;
        }

        private IRepository<T> Repository { get;  }
        
        public IEnumerable<T> Get() => Repository.Get();

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate) => Repository.Get(predicate);

        public T Get(Guid id) => Repository.Get(id);
        
        public void Add(T entity) => Repository.Add(entity);

        public void Delete(T entity) => Repository.Delete(entity);

        public void Update(T entity) => Repository.Update(entity);
    }
}