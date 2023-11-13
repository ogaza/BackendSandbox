using System.Threading.Tasks;
using CQRS.Commands;

namespace CQRS.Customers
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