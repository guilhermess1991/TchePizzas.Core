using FluentValidator;

namespace TchePizzas.Domain.ValueObjects
{
    public class Address : Notifiable
    {
        public Address(string city, string neighborhood, string street, int number, int? extraNumber)
        {
            City = city;
            Neighborhood = neighborhood;
            Street = street;
            Number = number;
            ExtraNumber = extraNumber;

            new ValidationContract<Address>(this)
                .IsRequired(x => x.City, "Cidade é obrigatório.")
                .IsRequired(x => x.Neighborhood, "Bairro é obrigatório.")
                .IsRequired(x => x.Street, "Rua/Avenida é obrigatório.")
                .IsGreaterOrEqualsThan(x => x.Number, 1, "Coloque um número válido");

        }

        public string City{ get; private set;}

        public string Neighborhood{get;private set;}

        public string Street{ get; private set;}

        public int Number{get;private set;}

        public int? ExtraNumber{get;private set;}

        public override string ToString()
        {
            //Formata saída padrão para endereço
            //Rua|Avenida, Numero, Complemento, Bairro, Cidade

            //Verifica se foi informado o complemento
            if(ExtraNumber > 0)
                return $"{Street}, {Number}, {ExtraNumber}, {Neighborhood}, {City}";
            

            return $"{Street}, {Number}, {Neighborhood}, {City}";
        }
    }
}
