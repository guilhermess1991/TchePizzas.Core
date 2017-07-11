using System.Collections.Generic;
using TchePizzas.Domain.ValueObjects;
using TchePizzas.Shared.Commands;

namespace TchePizzas.Domain.Commands.Input
{
    public class RegisterOrderWithoutCustomerCommand : ICommand
    {
		public string Name { get; set; }

		public string Phone { get; set; }

		public string Email { get; set; }

        public string City{get;set;}

        public string Neighborhood{get;set;}

        public string Street{get;set;}

        public int NumberAddress{get;set;}

        public int? ExtraNumberAddress{get;set;}

		public decimal DeliveryFee { get; set; }

        public int Discount{get;set;}

        public IEnumerable<RegisterOrderItemCommand> Itens { get; set; }
    }
}
