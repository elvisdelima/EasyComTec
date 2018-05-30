using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

        public T Add(T entity) => _unitOfWork.Context.Set<T>().Add(entity).Entity;
       
        public T Get(Guid id) => _unitOfWork.Context.Set<T>().FirstOrDefault(e => e.Id == id);

        public IEnumerable<T> Get() => _unitOfWork.Context.Set<T>().AsEnumerable();

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
            => _unitOfWork.Context.Set<T>().Where(predicate).AsEnumerable();
        
        public T Update(T entity)
        {
            //_unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            return _unitOfWork.Context.Set<T>().Attach(entity).Entity;    
        }
        
        public void Delete(Guid id)
        {
            var existing = _unitOfWork.Context.Set<T>().FirstOrDefault(e => e.Id == id);
            if (existing != null) _unitOfWork.Context.Set<T>().Remove(existing);
        }

    }
}
