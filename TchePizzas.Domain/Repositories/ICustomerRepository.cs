using System;
using System.Collections.Generic;
using TchePizzas.Domain.Commands.Results;
using TchePizzas.Domain.Entities;

namespace TchePizzas.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);

        IEnumerable<GetCustomerResult> GetAll();

        void Save(Customer customer);

        void Update(Customer customer);

        void Delete(Guid id);

        bool EmailExists(string email);

    }
}
