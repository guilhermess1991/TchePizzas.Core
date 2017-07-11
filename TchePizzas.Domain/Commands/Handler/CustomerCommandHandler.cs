using System;
using FluentValidator;
using TchePizzas.Domain.Commands.Input;
using TchePizzas.Domain.Commands.Results;
using TchePizzas.Domain.Entities;
using TchePizzas.Domain.Repositories;
using TchePizzas.Domain.Services;
using TchePizzas.Domain.ValueObjects;
using TchePizzas.Shared.Commands;

namespace TchePizzas.Domain.Commands.Handler
{
    public class CustomerCommandHandler : Notifiable
        , ICommandHandler<RegisterCustomerCommand>
    {
        //Variables
        readonly ICustomerRepository _customerRepository;

        //Constructor
        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //Register a new Customer
        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            //Step 1. Verify that the email already exists 
            if(_customerRepository.EmailExists(command.Email))
            {
                AddNotification("Email","E-mail já existe.");
                return null;
            }
			//Step 2. Prepare the new customer
			var phone = new Phone(command.Phone);

			var address = new Address(
								command.City,
								command.Neighborhood,
								command.Street,
								command.NumberAddress,
								command.ExtraNumberAddress
						);

			var customer = new Customer(command.Name, phone, command.Email, address);

			//Step 3. Inherit validations
			AddNotifications(phone.Notifications);
            AddNotifications(address.Notifications);
            AddNotifications(customer.Notifications);

            //Step 4. Insert customer
            if (!IsValid())
                return null;
            
            _customerRepository.Save(customer);

			//Step 5. Send e-mail of wellcome


            //Step 6. Return information
            return new RegisterCustomerResult{
                Id = Guid.NewGuid(),
                Name = "Guilherme Souza"
            };

        }
    }
}
