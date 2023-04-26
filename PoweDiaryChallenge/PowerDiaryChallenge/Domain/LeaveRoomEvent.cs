namespace PowerDiaryChallenge.Domain;

public class LeaveRoomEvent : ChatEvent
{
    public LeaveRoomEvent(string user, DateTime createdAt) : base(ChatEventType.LeaveRoom, user, createdAt) { }
}