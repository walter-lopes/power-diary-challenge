namespace PowerDiaryChallenge.Repositories;

public interface IChatEventRepository
{
    void Add(ChatEvent @event);

    IEnumerable<ChatEvent> GetByPeriod(DateTime start, DateTime end);
}