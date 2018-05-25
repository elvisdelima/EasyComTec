using Application.Interfaces;
using Domain;
using Infrastructure.Interfaces;

namespace Application.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        public CustomerService(IRepository<Customer> repository) : base(repository)
        {   
        }
    }
}