using FluentValidator;
using TchePizzas.Shared.Entities;

namespace TchePizzas.Domain.Entities
{
    public class OrderItem : Entity
    {
        //Contructor//
        public OrderItem(Pizza pizza, int quantity)
        {
            Pizza = pizza;
            Quantity = quantity;

            //Class validations//
            new ValidationContract<OrderItem>(this)
                .IsNotNull(Pizza, "Deve ser selecionada ao menos uma pizza.")
                .IsGreaterThan(x => x.Quantity, 0, $"Deve ser selecionada ao menos uma unidade da pizza {Pizza.Flavour}.")
                .IsGreaterThan(x => x.Pizza.QuantityInStock, quantity + 1, $"Não temos tantas pizzas de {Pizza.Flavour} em estoque.");

			//Reduce the stock
			Pizza.DecreaseQuantity(quantity);
        }

        //Properties//
        public Pizza Pizza { get; private set; }
		public int Quantity { get; private set; }

        //Methods//

        //Calcula total do item pedido (Quantidade seleciona vezes o valor da pizza)
        public decimal Total() => Pizza.Price * Quantity;
    }
}
