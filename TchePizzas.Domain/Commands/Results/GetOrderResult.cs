using System;
using TchePizzas.Domain.Enums;
using TchePizzas.Domain.ValueObjects;
using TchePizzas.Shared.Commands;

namespace TchePizzas.Domain.Commands.Results
{
    public class GetOrderResult : ICommandResult
    {
        public Guid Number{get;set;}

        public string Name{get;set;}

        public Address Address{get;set;}

        public Phone Phone {get; set;}

        public EOrderStatus Status{get;set;}
    }
}
