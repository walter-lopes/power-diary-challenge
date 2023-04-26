using PowerDiaryChallenge.Domain;

namespace PowerDiaryChallenge;

public abstract class ChatEvent
{
    protected ChatEvent(ChatEventType type, string user, DateTime createdAt)
    {
        Type = type;
        User = user;
        CreatedAt = createdAt;
    }
    
    public ChatEventType Type { get; protected set; }

    public string User { get; protected set; }
    

    public DateTime CreatedAt { get; protected set; }
}