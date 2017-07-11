using TchePizzas.Shared.Commands;

namespace TchePizzas.Domain.Commands.Results
{
    public class GetUserResult : ICommandResult
    {
        public string Username{get;set;}
    }
}
