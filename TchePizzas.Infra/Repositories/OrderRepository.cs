using System;
using System.Collections.Generic;
using TchePizzas.Domain.Commands.Results;
using TchePizzas.Domain.Entities;
using TchePizzas.Domain.Repositories;

namespace TchePizzas.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Order Get(Guid id)
        {
            return null;
        }

        public IEnumerable<GetOrderResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public GetOrderResult GetOrder(Guid number)
        {
            throw new NotImplementedException();
        }

        public void Save(Order order)
        {
            
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
