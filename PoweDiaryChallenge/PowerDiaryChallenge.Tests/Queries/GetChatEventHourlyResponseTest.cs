using PowerDiaryChallenge.Domain;
using PowerDiaryChallenge.Queries.Responses;

namespace PowerDiaryChallenge.Tests.Queries;

public class GetChatEventHourlyResponseTest
{
    [Test]
    public void ShouldWriteChatEventHourlyMessages()
    {
        var bobComment = new CommentEvent("Bob", "comment", DateTime.Now);
        var kateComment = new CommentEvent("Kate", "comment", DateTime.Now);

        var bobHighFive = new HighFiveAnotherUserEvent("Bob", "Kate", DateTime.Now);
        var bobHighFiveLinda = new HighFiveAnotherUserEvent("Bob", "Linda", DateTime.Now);

        var kateEnter = new EnterRoomEvent("Kate", DateTime.Now);
        var bobEnter = new EnterRoomEvent("Bob", DateTime.Now);

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