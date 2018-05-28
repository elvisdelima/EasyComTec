using System;
using Application.Interfaces;
using Domain;
using Domain.DTO.Customer;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CustomerController : BaseController<Customer, ICustomerService>
    {
        public CustomerController(ICustomerService customerService)
            : base(customerService)
        { }
        
        // GET api/Controller/{id}
        [HttpGet("{id}")]
        public IActionResult Get(Guid id) => base.Get<CustomerDto>(id);

        // GET api/Controller
        [HttpGet]
        public IActionResult Get() => GetAll<CustomerDto>();

        // POST api/Controller
        [HttpPost]
        public IActionResult Post([FromBody]CreateCustomerDto createCustomerDto) => base.Post<CreateCustomerDto, Customer>(createCustomerDto);

        // PUT api/Controller
        [HttpPut]
        public IActionResult Put([FromBody]UpdateCustomerDto updateCustomerDto) => base.Put<UpdateCustomerDto, Customer>(updateCustomerDto);

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) => base.Delete(id);
    }
}