namespace PowerDiaryChallenge.Domain;

public class HighFiveAnotherUserEvent : ChatEvent
{
    public string ReceiverUser { get; private set; }
    
    public HighFiveAnotherUserEvent(string user, string receiverUser) : base(ChatEventType.HighFiveAnotherUser, user)
    {
        ReceiverUser = receiverUser;
    }
}