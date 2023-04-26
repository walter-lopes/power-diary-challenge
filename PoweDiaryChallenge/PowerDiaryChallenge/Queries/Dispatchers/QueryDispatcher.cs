using Microsoft.Extensions.DependencyInjection;

namespace PowerDiaryChallenge.Queries.Dispatchers;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public TResponse Query<TQuery, TResponse>(TQuery query) where TQuery : class
    {
        var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResponse>>();
        return handler.Handle(query);
    }
}