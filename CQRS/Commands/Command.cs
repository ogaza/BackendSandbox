using System;
using System.Threading.Tasks;
using Autofac;

namespace CQRS.Commands 
{
    public class CommandBase : ICommand
    {
        public Guid CommandUId { get; set; } = Guid.NewGuid();
    }

    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ILifetimeScope _lifetimeScope;

        public CommandDispatcher(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }


        public async Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = _lifetimeScope.ResolveOptional<ICommandHandler<TCommand>>();
            if (commandHandler == null)
            {
                throw new InvalidOperationException($"Not able to get command handler for command: {typeof(TCommand).Name}");
            }

            await commandHandler.Handle(command);
        }
    }
}