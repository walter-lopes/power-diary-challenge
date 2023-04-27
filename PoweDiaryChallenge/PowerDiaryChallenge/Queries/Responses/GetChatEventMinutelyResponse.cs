using System.Text;
using PowerDiaryChallenge.Domain;

namespace PowerDiaryChallenge.Queries.Responses;

public class GetChatEventMinutelyResponse
{
    public GetChatEventMinutelyResponse(IEnumerable<ChatEvent> events)
    {
        Events = events
            .OrderBy(x=> x.CreatedAt)
            .Select(x => new GetChatEventMinutelyItemResponse(x))
            .ToList();
    }
    
    public IEnumerable<GetChatEventMinutelyItemResponse> Events { get; set; }
    
    public string GenerateMessage()
    {
        var sb = new StringBuilder();
        foreach (var @event in Events)
        {
            sb.Append($"{@event.Minute}: ");
            sb.Append(@event.Message);
            sb.AppendLine();
        }

        return sb.ToString();
    }
}

public class GetChatEventMinutelyItemResponse
{
    public GetChatEventMinutelyItemResponse(ChatEvent @event)
    {
        Minute = @event.CreatedAt.ToString("hh:mm tt");
        Message = BuildMessage(@event);
    }
    
    public string Minute { get; private set; }

    public string Message { get; private set; }
    
    private static string BuildMessage(ChatEvent @event)
    {
        switch (@event.Type)
        {
            case ChatEventType.Comment:
                var chatEvent = @event as CommentEvent;
                return $"{chatEvent?.User} comments: '{chatEvent?.Comment}'";
            case ChatEventType.EnterRoom:
                return $"{@event.User} enters the room";
            case ChatEventType.LeaveRoom:
                return $"{@event.User} leaves";
            case ChatEventType.HighFiveAnotherUser:
                var highFiveAnotherUserEvent = @event as HighFiveAnotherUserEvent;
                return  $"{highFiveAnotherUserEvent?.User} high-fives {highFiveAnotherUserEvent?.ReceiverUser}'";
            default:
                throw new Exception("Chat Event Type not found.");
        }
    }
}