using System;
using System.Collections.Generic;
using TchePizzas.Domain.Commands.Results;
using TchePizzas.Domain.Entities;

namespace TchePizzas.Domain.Repositories
{
    public interface IOrderRepository
    {
        Order Get(Guid id);
        
        IEnumerable<GetOrderResult> GetAll();

        GetOrderResult GetOrder(Guid number);

		void Save(Order order);

		void Update(Order order);

		void Delete(Guid id);
    }
}
