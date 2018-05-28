using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain;
using Infrastructure.CrossCutting;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BaseController<TEntity, TService> : Controller
        where TEntity : Entity
        where TService : IService<TEntity>
    {
        private readonly TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

        public virtual IActionResult Get<TSource, TDestination>(Guid id)
            => Ok(new List<TDestination> { AppMapper.Instance.Map<TEntity, TDestination>(_service.Get(id))});    
            
        public virtual IActionResult GetAll<TSource, TDestination>() 
            => Ok(AppMapper.Instance.Map<List<TSource>, List<TDestination>>(_service.Get() as List<TSource>));

        public virtual IActionResult Post<TSource, TDestination>([FromBody]TSource source) where TDestination : Entity
        {
            var entityCreated = _service.Add(AppMapper.Instance.Map<TSource, TEntity>(source));
            var entityResponse = AppMapper.Instance.Map<TEntity, TDestination>(entityCreated);

            return new CreatedResult("", entityResponse);
        }

        public virtual IActionResult Put<TSource, TDestination>([FromBody]TSource source) where TDestination : Entity
        {
            var entityUpdated = _service.Update(AppMapper.Instance.Map<TSource, TEntity>(source));
            var entityResponse = AppMapper.Instance.Map<TEntity, TDestination>(entityUpdated);

            return Ok(entityResponse);
        }

        public virtual IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return new NoContentResult();
        }
    }
}