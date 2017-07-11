using System;
using System.Collections.Generic;
using TchePizzas.Domain.Commands.Results;
using TchePizzas.Domain.Entities;

namespace TchePizzas.Domain.Repositories
{
    public interface IPizzaRepository
    {
        Pizza Get(Guid id);

        IEnumerable<GetPizzaResult> GetAll();

        void Save(Pizza pizza);

        void Update(Pizza pizza);

        void Delete(Guid id);
    }
}
