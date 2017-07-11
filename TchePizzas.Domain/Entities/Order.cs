using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using TchePizzas.Domain.Enums;
using TchePizzas.Shared.Entities;

namespace TchePizzas.Domain.Entities
{
    public class Order : Entity
    {
        //Variables//
        readonly IList<OrderItem> _items;

        //Constructor//
        public Order(Customer customer, DateTime createDate, EOrderStatus status, decimal deliveryFee, decimal discount)
        {
            Customer = customer;
            CreateDate = createDate;
            Number = Guid.NewGuid().ToString().Substring(0, 10); ;
            Status = status;
            DeliveryFee = deliveryFee;
            Discount = discount;
            _items = new List<OrderItem>();

			//Class validations//
			new ValidationContract<Order>(this)
                .IsGreaterThan(x => x.DeliveryFee, 0)
			    .IsGreaterThan(x => x.Discount, -1);
        }

        //Properties//
        public Customer Customer { get; private set; }

		public DateTime CreateDate { get; private set; }

		public string Number { get; private set; }

		public EOrderStatus Status { get; private set; }

		public decimal DeliveryFee { get; private set; }

		public decimal Discount { get; private set; }

        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();


        //Methods//
		public decimal SubTotal() => Items.Sum(x => x.Total());

        public decimal Total() => SubTotal() + DeliveryFee + Discount;

		public void AddItem(OrderItem item)
		{
			AddNotifications(item.Notifications);
			if (item.IsValid())
				_items.Add(item);
		}
    }
}
