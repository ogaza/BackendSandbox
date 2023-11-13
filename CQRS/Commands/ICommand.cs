using System;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }

    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }

    public interface ICommand
    {
        Guid CommandUId { get; }
    }
}