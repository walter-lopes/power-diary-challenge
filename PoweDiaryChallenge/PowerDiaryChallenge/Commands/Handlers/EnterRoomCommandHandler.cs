using PowerDiaryChallenge.Commands;
using PowerDiaryChallenge.Domain;
using PowerDiaryChallenge.Repositories;

namespace PowerDiaryChallenge.Commands.Handlers;

public class EnterRoomCommandHandler : ICommandHandler<EnterRoomCommand>
{
    private readonly IChatEventRepository _chatEventRepository;

    public EnterRoomCommandHandler(IChatEventRepository chatEventRepository)
    {
        _chatEventRepository = chatEventRepository;
    }

    public void Handle(EnterRoomCommand command)
    {
        var commentEvent = new EnterRoomEvent(command.User, DateTime.Now);
        
        _chatEventRepository.Add(commentEvent);
    }
}