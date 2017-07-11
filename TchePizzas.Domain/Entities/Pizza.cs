using TchePizzas.Shared.Entities;
using FluentValidator;

namespace TchePizzas.Domain.Entities
{
    public class Pizza : Entity
    {
        //Constructor//
        public Pizza(string flavour, decimal price, string image, int quantityInStock)
        {
            Flavour = flavour;
            Price = price;
            Image = image;
            QuantityInStock = quantityInStock;


            //Class validations
            new ValidationContract<Pizza>(this)
                .IsRequired(x => x.Flavour, "Titulo é obrigátorio.")
                .IsGreaterThan(x => x.Price, 0, "Preço deve ser maior que zero.");
        }

        //Properties//
        public string Flavour { get; private set; }

		public decimal Price { get; private set; }

		public string Image { get; private set; }

		public int QuantityInStock { get; private set; }


		//Methods//
		
        //Retira do estoque a quantidade recebida
		public void DecreaseQuantity(int quantity){

            if (QuantityInStock < 0)
            {
                AddNotification("QuantityInStock", $"Ficamos sem estoque de pizza {Flavour}.");
            }
            else
            {
                QuantityInStock -= quantity;    
            }
        }
	}
}
