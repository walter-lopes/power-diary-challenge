using PowerDiaryChallenge.Commands;
using PowerDiaryChallenge.Domain;
using PowerDiaryChallenge.Repositories;

namespace PowerDiaryChallenge.Commands.Handlers;

public class LeaveRoomCommandHandler : ICommandHandler<LeaveRoomCommand>
{
    private readonly IChatEventRepository _chatEventRepository;

    public LeaveRoomCommandHandler(IChatEventRepository chatEventRepository)
    {
        _chatEventRepository = chatEventRepository;
    }
    
    public void Handle(LeaveRoomCommand command)
    {
        var leaveRoomEvent= new LeaveRoomEvent(command.User, DateTime.Now);
        
        _chatEventRepository.Add(leaveRoomEvent);
    }
}