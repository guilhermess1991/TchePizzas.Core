using FluentValidator;
using TchePizzas.Domain.ValueObjects;
using TchePizzas.Shared.Entities;

namespace TchePizzas.Domain.Entities
{
    public class Customer : Entity
    {
        //Contructor//
        public Customer(string name, Phone phone, string email, Address address)
        {
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;

            //Class validations
            new ValidationContract<Customer>(this)
                .IsRequired(x => x.Name, "Nome é obrigátorio.")
                .IsEmail(x => x.Email, "E-mail não é válido.");

            //Inherit validations
            AddNotifications(phone.Notifications);
            AddNotifications(address.Notifications);
        }


        //Properties//
        public string Name { get; private set; }

        public Phone Phone { get; private set; }

        public string Email { get; private set; }

        public Address Address { get; private set; }

    }

}