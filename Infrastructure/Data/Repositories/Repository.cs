using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;
using Infrastructure.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly IUnitOfWork _unitOfWork;

        protected Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(T entity) => _unitOfWork.Context.Set<T>().Add(entity);


        public void Delete(T entity)
        {
            var existing = _unitOfWork.Context.Set<T>().Find(entity);
            if (existing != null) _unitOfWork.Context.Set<T>().Remove(existing);
        }

        public IEnumerable<T> Get() => _unitOfWork.Context.Set<T>().AsEnumerable();


        public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Context.Set<T>().Where(predicate).AsEnumerable();
        }

        public void Update(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<T>().Attach(entity);
        }
    }
}
