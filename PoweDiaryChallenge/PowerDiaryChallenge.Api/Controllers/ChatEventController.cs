using Microsoft.AspNetCore.Mvc;
using PowerDiaryChallenge.Commands;
using PowerDiaryChallenge.Commands.Dispachers;
using PowerDiaryChallenge.Queries;
using PowerDiaryChallenge.Queries.Dispatchers;
using PowerDiaryChallenge.Queries.Responses;

namespace PowerDiaryChallenge.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatEventController : ControllerBase
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;
    
    public ChatEventController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
    {
        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost("enter-room")]
    public IActionResult EnterRoom([FromBody] EnterRoomCommand command)
    {
        _commandDispatcher.Send(command);

        return Ok();
    }
    
    [HttpPost("leave-room")]
    public IActionResult LeaveRoom([FromBody] LeaveRoomCommand command)
    {
        _commandDispatcher.Send(command);

        return Ok();
    }
    
    [HttpPost("comment")]
    public IActionResult EnterRoom([FromBody] CommentCommand command)
    {
        _commandDispatcher.Send(command);

        return Ok();
    }
    
    [HttpPost("high-five")]
    public IActionResult HighFive([FromBody] HighFiveAnotherUserCommand command)
    {
        _commandDispatcher.Send(command);

        return Ok();
    }
    
    [HttpGet("minutely")]
    public IActionResult GetMinutely()
    {
        var query = new GetChatEventMinutelyQuery(DateTime.Now.AddDays(-1), DateTime.Now);
        var response =  _queryDispatcher.Query<GetChatEventMinutelyQuery, GetChatEventMinutelyResponse>(query);

        return Ok(response);
    }
    
    [HttpGet("hourly")]
    public IActionResult GetHourly()
    {
        var query = new GetChatEventHourlyQuery(DateTime.Now.AddDays(-1), DateTime.Now);
        var response = _queryDispatcher.Query<GetChatEventHourlyQuery, GetChatEventHourlyResponse>(query);

        return Ok(response);
    }
    
}