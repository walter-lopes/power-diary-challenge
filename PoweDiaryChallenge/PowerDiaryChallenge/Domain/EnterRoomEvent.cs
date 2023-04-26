namespace PowerDiaryChallenge.Domain;

public class EnterRoomEvent : ChatEvent
{
    public EnterRoomEvent(string user, DateTime createdAt) : base(ChatEventType.EnterRoom, user, createdAt) { }
}