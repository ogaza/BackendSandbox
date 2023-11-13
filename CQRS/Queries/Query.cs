using System.Threading.Tasks;
using Autofac;

namespace CQRS.Queries
{
    internal class QueryDispatcher : IQueryDispatcher
    {
        private readonly ILifetimeScope _lifetimeScope;

        public QueryDispatcher(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public async Task<TReturn> Dispatch<TReturn, TQuery>(TQuery query) where TQuery : IQuery
        {
            var queryHandler = _lifetimeScope.Resolve<IQueryHandler<TQuery, TReturn>>();
            
            return await queryHandler.Handle(query);
        }
    }
}