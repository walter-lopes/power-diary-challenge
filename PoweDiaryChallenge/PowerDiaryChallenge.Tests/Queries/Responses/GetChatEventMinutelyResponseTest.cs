using PowerDiaryChallenge.Domain;
using PowerDiaryChallenge.Queries.Responses;

namespace PowerDiaryChallenge.Tests.Queries.Responses;

public class GetChatEventMinutelyResponseTest
{
    [Test]
    public void ShouldGenerateMessage()
    {
        var sevenPm = new DateTime(2023, 04, 27, 07, 00, 00);
        var sevenTenPm = new DateTime(2023, 04, 27, 07, 10, 00);
        var ninePm = new DateTime(2023, 04, 27, 09, 00, 00);
        var nineTenPm = new DateTime(2023, 04, 27, 09, 10, 00);
        
        var enterRoomEvent = new EnterRoomEvent("Bob",sevenPm);
        var commentEvent = new CommentEvent("Bob", "oh no!", sevenTenPm);
        var leaveRoomEvent = new LeaveRoomEvent("Bob", nineTenPm);
        var highFiveAnotherUserEvent = new HighFiveAnotherUserEvent("Bob", "Kate", ninePm);

        var events = new List<ChatEvent>()
        {
            enterRoomEvent,
            commentEvent,
            leaveRoomEvent,
            highFiveAnotherUserEvent
        };

        var response = new GetChatEventMinutelyResponse(events);

        var message = response.GenerateMessage();
        
        Assert.That(message, Is.EqualTo("07:00 AM: Bob enters the room\n07:10 AM: Bob comments: 'oh no!'\n09:00 AM: Bob high-fives Kate'\n09:10 AM: Bob leaves\n"));
    }
}