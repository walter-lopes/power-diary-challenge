using PowerDiaryChallenge.Domain;

namespace PowerDiaryChallenge.Tests.Domain;

public class EnterRoomEventTest
{
    [Test]
    public void ShouldInitAllValuesCorrect()
    {
        var @event = new EnterRoomEvent("Bob", DateTime.Now);
        
        Assert.Multiple(() =>
        {
            Assert.That(@event.Type, Is.EqualTo(ChatEventType.EnterRoom));
            Assert.That(@event.User, Is.EqualTo("Bob"));
        });
    }
}