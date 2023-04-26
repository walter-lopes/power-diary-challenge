namespace PowerDiaryChallenge.Domain;

public class CommentEvent : ChatEvent
{
    public CommentEvent(string user, string comment) : base(ChatEventType.Comment, user)
    {
        Comment = comment;
    }
    
    public string Comment { get; private set; }
}