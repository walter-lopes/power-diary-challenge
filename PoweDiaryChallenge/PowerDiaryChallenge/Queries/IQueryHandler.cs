namespace PowerDiaryChallenge.Queries;

public interface IQueryHandler<in TQuery, out TResponse>
{
    TResponse Handle(TQuery query);
}