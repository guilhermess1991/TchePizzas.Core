using TchePizzas.Shared.Commands;

namespace TchePizzas.Domain.Commands.Input
{
    public class RegisterCustomerCommand : ICommand
    {
        public string Name{get;set;}

        public string Phone{get;set;}

        public string Email{get;set;}
		
        public string City { get; set; }

		public string Neighborhood { get; set; }

		public string Street { get; set; }

		public int NumberAddress { get; set; }

		public int? ExtraNumberAddress { get; set; }

	}
}
