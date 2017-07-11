using System;
using System.Collections.Generic;
using System.IO;
using TchePizzas.Domain.Commands.Results;
using TchePizzas.Domain.Entities;
using TchePizzas.Domain.Repositories;

namespace TchePizzas.Infra.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        public void Delete(Guid id)
        {
            
        }

        public Pizza Get(Guid id)
        {
            return new Pizza("Calabresa", (decimal)17.00, "calabresa.jpg", 10);
        }

        public IEnumerable<GetPizzaResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Pizza pizza)
        {
            
        }

        public void Update(Pizza pizza)
        {
           
        }
    }
}
