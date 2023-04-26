using PowerDiaryChallenge.Domain;
using PowerDiaryChallenge.Queries.Responses;

namespace PowerDiaryChallenge.Tests.Queries;

public class GetChatEventMinutelyResponseTest
{
    [Test]
    public void ShouldGenerateMessage()
    {
        var enterRoomEvent = new EnterRoomEvent("Bob", DateTime.Now);
        var commentEvent = new CommentEvent("Bob", "oh no!", DateTime.Now);
        var leaveRoomEvent = new LeaveRoomEvent("Bob", DateTime.Now);
        var highFiveAnotherUserEvent = new HighFiveAnotherUserEvent("Bob", "Kate", DateTime.Now);

        var events = new List<ChatEvent>()
        {
            enterRoomEvent,
            commentEvent,
            leaveRoomEvent,
            highFiveAnotherUserEvent
        };

        var response = new GetChatEventMinutelyResponse(events);

        var message = response.GenerateMessage();
    }
}