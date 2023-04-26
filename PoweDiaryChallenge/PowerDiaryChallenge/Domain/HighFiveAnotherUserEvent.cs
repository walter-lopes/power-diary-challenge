namespace PowerDiaryChallenge.Domain;

public class HighFiveAnotherUserEvent : ChatEvent
{
    public string ReceiverUser { get; private set; }
    
    public HighFiveAnotherUserEvent(string user, string receiverUser, DateTime createdAt) 
        : base(ChatEventType.HighFiveAnotherUser, user, createdAt)
    {
        ReceiverUser = receiverUser;
    }
}