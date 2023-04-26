namespace PowerDiaryChallenge.Queries.Dispatchers;

public interface IQueryDispatcher
{
    TResult Query<TQuery, TResult>(TQuery query) where TQuery : class;
}