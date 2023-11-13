namespace CQRS.Queries
{
    public interface IQueryHandler<in TQuery, TQueryResult> where TQuery : IQuery
    {
        Task<TQueryResult> Handle(TQuery query);
    }

    public interface IQueryDispatcher
    {
        Task<TReturn> Dispatch<TReturn, TQuery>(TQuery query) where TQuery : IQuery;
    }

    public interface IQuery
    {
    }
}