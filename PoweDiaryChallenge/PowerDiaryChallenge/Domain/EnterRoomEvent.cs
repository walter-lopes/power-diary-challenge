namespace PowerDiaryChallenge.Domain;

public class EnterRoomEvent : ChatEvent
{
    public EnterRoomEvent(string user) : base(ChatEventType.EnterRoom, user) { }
}