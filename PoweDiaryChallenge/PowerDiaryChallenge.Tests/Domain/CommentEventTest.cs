using PowerDiaryChallenge.Domain;

namespace PowerDiaryChallenge.Tests.Domain;

public class CommentEventTest
{

    
    [Test]
    public void ShouldInitAllValuesCorrect()
    {
        var commentEvent = new CommentEvent("Bob", "'oh yes!'", DateTime.Now);
        
        Assert.Multiple(() =>
        {
            Assert.That(commentEvent.Type, Is.EqualTo(ChatEventType.Comment));
            Assert.That(commentEvent.Comment, Is.EqualTo("'oh yes!'"));
            Assert.That(commentEvent.User, Is.EqualTo("Bob"));
        });
    }
}