using System;
using System.Collections.Generic;
using TchePizzas.Shared.Commands;

namespace TchePizzas.Domain.Commands.Input
{
    public class RegisterOrderCommand : ICommand
    {
        public Guid Customer{get;set;}
        
        public decimal DeliveryFee{get;set;}

        public int Discount{get;set;}

        public IEnumerable<RegisterOrderItemCommand> Itens { get; set; }

    }
    
}
