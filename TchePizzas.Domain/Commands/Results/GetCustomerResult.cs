using System;
using TchePizzas.Shared.Commands;

namespace TchePizzas.Domain.Commands.Results
{
    public class GetCustomerResult : ICommandResult
    {
        public string Name{get;set;}

        public string Phone{get;set;}

        public string Email{get;set;}
    }
}
