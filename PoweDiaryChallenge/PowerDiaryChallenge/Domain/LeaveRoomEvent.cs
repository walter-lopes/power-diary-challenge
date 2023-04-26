namespace PowerDiaryChallenge.Domain;

public class LeaveRoomEvent : ChatEvent
{
    public LeaveRoomEvent(string user) : base(ChatEventType.LeaveRoom, user) { }
}