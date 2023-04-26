namespace PowerDiaryChallenge.Repositories;

public class ChatEventInMemoryRepository : IChatEventRepository
{
    private readonly List<ChatEvent> _chatEvents = new List<ChatEvent>();

    public IEnumerable<ChatEvent> GetByPeriod(DateTime start, DateTime end)
        => _chatEvents.Where(chatEvent => chatEvent.CreatedAt >= start && chatEvent.CreatedAt <= end).ToList();

    public void Add(ChatEvent chatEvent)
        => _chatEvents.Add(chatEvent);
}