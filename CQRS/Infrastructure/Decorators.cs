using CQRS.Commands;
using System.Threading.Tasks;
using System.Transactions;

namespace CQRS.Infrastructure
{
    internal class TransactionCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _nextCommandHandler;
        private readonly AppDbContext _dbContext;

        public TransactionCommandHandlerDecorator(
            ICommandHandler<TCommand> nextCommandHandler, 
            AppDbContext AppDbContext)
        {
            _nextCommandHandler = nextCommandHandler;
            _dbContext = AppDbContext;
        }

        public async Task Handle(TCommand command)
        {
            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            await _nextCommandHandler.Handle(command);
            await _dbContext.SaveChangesAsync();
            transaction.Complete();
        }
    }
}