using PowerDiaryChallenge.Domain;

namespace PowerDiaryChallenge.Tests.Domain;

public class LeaveRoomEventTest
{
    [Test]
    public void ShouldInitAllValuesCorrect()
    {
        var @event = new LeaveRoomEvent("Bob", DateTime.Now);
        
        Assert.Multiple(() =>
        {
            Assert.That(@event.Type, Is.EqualTo(ChatEventType.LeaveRoom));
            Assert.That(@event.User, Is.EqualTo("Bob"));
        });
    }
}