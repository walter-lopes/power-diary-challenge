namespace PowerDiaryChallenge.Domain;

public class CommentEvent : ChatEvent
{
    public CommentEvent(string user, string comment, DateTime createdAt) : base(ChatEventType.Comment, user, createdAt)
    {
        Comment = comment;
    }
    
    public string Comment { get; private set; }
}