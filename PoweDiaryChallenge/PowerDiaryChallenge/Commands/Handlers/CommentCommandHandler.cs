using PowerDiaryChallenge.Commands;
using PowerDiaryChallenge.Domain;
using PowerDiaryChallenge.Repositories;

namespace PowerDiaryChallenge.Commands.Handlers;

public class CommentCommandHandler : ICommandHandler<CommentCommand>
{
    private readonly IChatEventRepository _chatEventRepository;
    
    public CommentCommandHandler(IChatEventRepository chatEventRepository)
    {
        _chatEventRepository = chatEventRepository;
    }
    
    public void Handle(CommentCommand command)
    {
        var commentEvent = new CommentEvent(command.User, command.Comment, DateTime.Now);
        
       _chatEventRepository.Add(commentEvent);
    }
}