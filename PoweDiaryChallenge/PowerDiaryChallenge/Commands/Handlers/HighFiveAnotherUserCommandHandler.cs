using PowerDiaryChallenge.Commands;
using PowerDiaryChallenge.Domain;
using PowerDiaryChallenge.Repositories;

namespace PowerDiaryChallenge.Commands.Handlers;

public class HighFiveAnotherUserCommandHandler : ICommandHandler<HighFiveAnotherUserCommand>
{
    private readonly IChatEventRepository _chatEventRepository;

    public HighFiveAnotherUserCommandHandler(IChatEventRepository chatEventRepository)
    {
        _chatEventRepository = chatEventRepository;
    }
    
    public void Handle(HighFiveAnotherUserCommand command)
    {
        var leaveRoomEvent= new HighFiveAnotherUserEvent(command.User, command.ReceiverUser, DateTime.Now);
        
        _chatEventRepository.Add(leaveRoomEvent);
    }
}