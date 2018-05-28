using System;
using System.Collections.Generic;
using System.Linq;
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

        protected IActionResult Get<TDestination>(Guid id)
            => Ok(new List<TDestination> { AppMapper.Instance.Map<TEntity, TDestination>(_service.Get(id))});    
            
        protected IActionResult GetAll<TDestination>() 
            => Ok(AppMapper.Instance.Map<List<TEntity>, List<TDestination>>(_service.Get().ToList()));

        [HttpPost]
        protected IActionResult Post<TSource, TDestination>([FromBody]TSource source) where TDestination : Entity
        {
            var entityCreated = _service.Add(AppMapper.Instance.Map<TSource, TEntity>(source));
            var entityResponse = AppMapper.Instance.Map<TEntity, TDestination>(entityCreated);

            return new CreatedResult("", entityResponse);
        }

        protected IActionResult Put<TSource, TDestination>([FromBody]TSource source) where TDestination : Entity
        {
            var entityUpdated = _service.Update(AppMapper.Instance.Map<TSource, TEntity>(source));
            var entityResponse = AppMapper.Instance.Map<TEntity, TDestination>(entityUpdated);

            return Ok(entityResponse);
        }

        protected IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return new NoContentResult();
        }
    }
}