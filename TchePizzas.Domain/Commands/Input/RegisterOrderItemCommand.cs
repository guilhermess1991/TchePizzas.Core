using System;
using TchePizzas.Shared.Commands;

namespace TchePizzas.Domain.Commands.Input
{
    
	public class RegisterOrderItemCommand : ICommand
	{
		public Guid Pizza { get; set; }

		public int Quantity { get; set; }

	}

}
