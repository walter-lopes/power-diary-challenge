using PowerDiaryChallenge.Domain;
using PowerDiaryChallenge.Queries.Responses;

namespace PowerDiaryChallenge.Tests.Queries.Responses;

public class GetChatEventHourlyResponseTest
{
    [Test]
    public void ShouldWriteChatEventHourlyMessages()
    {
        var sevenPm = new DateTime(2023, 04, 27, 07, 00, 00);
        var sevenTenPm = new DateTime(2023, 04, 27, 07, 10, 00);
        var ninePm = new DateTime(2023, 04, 27, 09, 00, 00);
        var nineTenPm = new DateTime(2023, 04, 27, 09, 10, 00);
        
        var bobComment = new CommentEvent("Bob", "comment", sevenTenPm);
        var kateComment = new CommentEvent("Kate", "comment", sevenTenPm);

        var bobHighFive = new HighFiveAnotherUserEvent("Bob", "Kate", ninePm);
        var bobHighFiveLinda = new HighFiveAnotherUserEvent("Bob", "Linda", nineTenPm);

        var kateEnter = new EnterRoomEvent("Kate", sevenPm);
        var bobEnter = new EnterRoomEvent("Bob", sevenPm);

        var events = new List<ChatEvent>()
        {
            bobComment,
            kateComment,
            bobHighFive,
            bobHighFiveLinda,
            kateEnter,
            bobEnter
        };


        var response = new GetChatEventHourlyResponse(events);

        var message = response.GenerateMessage();
        
        Assert.That(message, Is.EqualTo("07 AM\n2 people entered\n2 comments\n09 AM\n1 person high-fived  2 other people\n"));
    }
}