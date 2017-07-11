using System;
using TchePizzas.Shared.Commands;

namespace TchePizzas.Domain.Commands.Results
{
    public class RegisterCustomerResult : ICommandResult
    {

		public Guid Id { get; set; }

		public string Name { get; set; }
		
    }
}
