using System;
using TchePizzas.Shared.Commands;

namespace TchePizzas.Domain.Commands.Results
{
    public class RegisterOrderResult : ICommandResult
    {
        public Guid Number{get;set;}
    }
}
