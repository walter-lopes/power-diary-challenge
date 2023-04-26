using PowerDiaryChallenge.Domain;
using PowerDiaryChallenge.Queries.Responses;

namespace PowerDiaryChallenge.Tests.Queries;

public class GetChatEventMinutelyResponseTest
{
    [Test]
    public void ShouldGenerateMessage()
    {
        var enterRoomEvent = new EnterRoomEvent("Bob");
        var commentEvent = new CommentEvent("Bob", "oh no!");
        var leaveRoomEvent = new LeaveRoomEvent("Bob");
        var highFiveAnotherUserEvent = new HighFiveAnotherUserEvent("Bob", "Kate");

        var events = new List<ChatEvent>()
        {
            enterRoomEvent,
            commentEvent,
            leaveRoomEvent,
            highFiveAnotherUserEvent
        };

        var response = new GetChatEventMinutelyResponse(events);
    }
}