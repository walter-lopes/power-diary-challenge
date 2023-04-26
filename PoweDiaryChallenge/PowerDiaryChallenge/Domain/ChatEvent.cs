using PowerDiaryChallenge.Domain;

namespace PowerDiaryChallenge;

public abstract class ChatEvent
{
    protected ChatEvent(ChatEventType type, string user)
    {
        Type = type;
        User = user;
        CreatedAt = DateTime.Now;
    }
    
    public ChatEventType Type { get; protected set; }

    public string User { get; protected set; }
    

    public DateTime CreatedAt { get; protected set; }
}