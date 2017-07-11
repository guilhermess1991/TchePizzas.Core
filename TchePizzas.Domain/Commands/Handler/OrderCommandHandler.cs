using System;
using FluentValidator;
using TchePizzas.Domain.Commands.Input;
using TchePizzas.Domain.Commands.Results;
using TchePizzas.Domain.Entities;
using TchePizzas.Domain.Enums;
using TchePizzas.Domain.Repositories;
using TchePizzas.Domain.ValueObjects;
using TchePizzas.Shared.Commands;

namespace TchePizzas.Domain.Commands.Handler
{
    public class OrderCommandHandler : Notifiable
                ,ICommandHandler<RegisterOrderCommand>
                ,ICommandHandler<RegisterOrderWithoutCustomerCommand>
    {


        //Variables//
        readonly IPizzaRepository _pizzaRepository;
        readonly IOrderRepository _orderRepository;
        readonly ICustomerRepository _customerRepository;

		//Contructor//
		public OrderCommandHandler(IPizzaRepository pizzaRepository, IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _pizzaRepository = pizzaRepository;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        //Register a order with user saved
        public ICommandResult Handle(RegisterOrderCommand command)
        {
            //Step 1. Get User by id
            var customer = _customerRepository.Get(command.Customer);
            if (customer == null)
            {
                AddNotification("Customer", "Cliente não encontrado!");
                return null;
            }
            //Step 2. Create a new order
            var order = new Order(customer, DateTime.Now, EOrderStatus.Registered, command.DeliveryFee, command.Discount);

			//Step 3. Create and add itens into new order
            foreach (var item in command.Itens)
			{
				var pizza = _pizzaRepository.Get(item.Pizza);
				order.AddItem(new OrderItem(pizza, item.Quantity));
			}

			//Step 4. Inherit validations
			AddNotifications(customer.Notifications);
			AddNotifications(order.Notifications);

            //Step 4. Save order
            if (!order.IsValid())
                return null;

            //Step 5. Return order number 
            return new RegisterOrderResult
	            {
	                Number = Guid.NewGuid()
	            };
		}

        //Register a order without customer saved
        public ICommandResult Handle(RegisterOrderWithoutCustomerCommand command)
        {
            //Step 1. Create a new custommer
            var phone = new Phone(command.Phone);

            var address = new Address(
                                command.City, 
                                command.Neighborhood, 
                                command.Street, 
                                command.NumberAddress, 
                                command.ExtraNumberAddress
                        );

            var customer = new Customer(command.Name, phone, command.Email, address);

            //Step 2. Create a new order
            var order = new Order(customer, DateTime.Now, EOrderStatus.Registered, command.DeliveryFee, command.Discount);

            //Step 3. Create and add itens into new order
            foreach (var item in command.Itens)
            {
                var pizza = _pizzaRepository.Get(item.Pizza);
                order.AddItem(new OrderItem(pizza,item.Quantity));
            }

			//Step 4. Inherit validations
			AddNotifications(phone.Notifications);
			AddNotifications(address.Notifications);
			AddNotifications(customer.Notifications);
            AddNotifications(order.Notifications);

            //Step 5. Verify validations
            if (IsValid())
                return null;

            //Step 6. Save order
            _orderRepository.Save(order);

            //Step 7. Return number order 
            return new RegisterOrderResult
            {
                Number = order.Id
			};
        }
    }
}
