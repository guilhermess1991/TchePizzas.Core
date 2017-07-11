using System;
using System.Collections.Generic;
using TchePizzas.Domain.Commands.Results;
using TchePizzas.Domain.Entities;
using TchePizzas.Domain.Repositories;

namespace TchePizzas.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool EmailExists(string email)
        {
            return true;
        }

        public Customer Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetCustomerResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
