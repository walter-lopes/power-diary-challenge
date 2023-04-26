using PowerDiaryChallenge.Domain;

namespace PowerDiaryChallenge.Tests.Domain;

public class HighFiveAnotherUserEventTest
{
    [Test]
    public void ShouldInitAllValuesCorrect()
    {
        var @event = new HighFiveAnotherUserEvent("Bob", "Kate", DateTime.Now);
        
        Assert.Multiple(() =>
        {
            Assert.That(@event.Type, Is.EqualTo(ChatEventType.HighFiveAnotherUser));
            Assert.That(@event.ReceiverUser, Is.EqualTo("Kate"));
            Assert.That(@event.User, Is.EqualTo("Bob"));
        });
    }
}