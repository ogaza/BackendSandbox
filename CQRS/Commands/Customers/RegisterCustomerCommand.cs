using System.Threading.Tasks;

namespace CQRS.Commands.Customers
{
    public class RegisterCustomerCommand : CommandBase
    {
        internal class Handler : ICommandHandler<RegisterCustomerCommand>
        {
            public Handler()
            {
            }

            public async Task Handle(RegisterCustomerCommand command)
            {
            }
        }
    }
}