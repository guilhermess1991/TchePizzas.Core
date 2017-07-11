using System;
using TchePizzas.Shared.Commands;

namespace TchePizzas.Domain.Commands.Results
{
    public class GetPizzaResult : ICommandResult
    {
        public string Flavour {get;set;}

        public string Image{get;set;}
    }
}
