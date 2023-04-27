using NSubstitute;
using PowerDiaryChallenge.Commands;
using PowerDiaryChallenge.Commands.Handlers;
using PowerDiaryChallenge.Domain;
using PowerDiaryChallenge.Repositories;

namespace PowerDiaryChallenge.Tests.Commands;

public class CommentCommandHandlerTests
{
    [Test]
    public void Should_Save_Comment_Event()
    {
        var repositoryMock = Substitute.For<IChatEventRepository>();
        var command = new CommentCommand("Bob", "Oh, it's a test");

        var handler = new CommentCommandHandler(repositoryMock);

        handler.Handle(command);
        
        repositoryMock.Received().Add(Arg.Is<CommentEvent>(e => e.Type == ChatEventType.Comment));
        repositoryMock.Received().Add(Arg.Is<CommentEvent>(e => e.Comment == "Oh, it's a test"));
        repositoryMock.Received().Add(Arg.Is<CommentEvent>(e => e.User == "Bob"));
    }
}