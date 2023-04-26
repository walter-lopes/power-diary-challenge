using PowerDiaryChallenge.Domain;
using PowerDiaryChallenge.Queries.Responses;

namespace PowerDiaryChallenge.Tests.Queries;

public class GetChatEventHourlyResponseTest
{
    [Test]
    public void ShouldWriteChatEventHourlyMessages()
    {
        var bobComment = new CommentEvent("Bob", "comment");
        var kateComment = new CommentEvent("Kate", "comment");

        var bobHighFive = new HighFiveAnotherUserEvent("Bob", "Kate");
        var bobHighFiveLinda = new HighFiveAnotherUserEvent("Bob", "Linda");

        var kateEnter = new EnterRoomEvent("Kate");
        var bobEnter = new EnterRoomEvent("Bob");

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
    }
}