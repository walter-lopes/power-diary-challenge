using System.Text;
using PowerDiaryChallenge.Domain;

namespace PowerDiaryChallenge.Queries.Responses;

public class GetChatEventHourlyResponse
{
    public GetChatEventHourlyResponse(IEnumerable<ChatEvent> events)
    {
        var eventsByHour = events
            .GroupBy(x => x.CreatedAt.ToString("hh tt"), x => x)
            .ToDictionary(x => x.Key, x => x.ToList());

        Events = eventsByHour.Select(x => new GetChatEventHourlyItemResponse(x.Key, x.Value)).ToList();
    }
    
    public IEnumerable<GetChatEventHourlyItemResponse> Events { get; private set; }
    
    public string GenerateMessage()
    {
        var sb = new StringBuilder();
        foreach (var @event in Events)
        {
            sb.AppendLine(@event.Hour);

            foreach (var message in @event.Messages)
            {
                sb.AppendLine(message);
            }
        }

        return sb.ToString();
    }
}

public class GetChatEventHourlyItemResponse
{
    public GetChatEventHourlyItemResponse(string hour, List<ChatEvent> events)
    {
        Hour = hour;
        Messages = new List<string>();
        BuildMessage(events);
    }
    
    public string Hour { get; set; }

    public List<string> Messages { get; private set; }

    private void BuildMessage(List<ChatEvent> events)
    {
        var countEnters = events.Count(x => x.Type == ChatEventType.EnterRoom);
        
        var countLeaves = events.Count(x => x.Type == ChatEventType.LeaveRoom);


        var highFiveEvents = events
            .Where(x => x.Type == ChatEventType.HighFiveAnotherUser)
            .Cast<HighFiveAnotherUserEvent>().ToList();
        
        var countUsersHighFived =
            highFiveEvents
                .DistinctBy(x => x.User)
                .Count();
                                            
        
        var countUsersHighFivedReceived = highFiveEvents
            .DistinctBy(x => x.ReceiverUser)
            .Count();
            
            
        var countComments = events.Count(x => x.Type == ChatEventType.Comment);
        

        AddEnterRoomMessage(countEnters);
        AddLeaveRoomMessage(countLeaves);
        AddCommentMessage(countComments);
        AddHighFiveMessage(countUsersHighFived, countUsersHighFivedReceived);
    }

    private void AddEnterRoomMessage(int countEnters)
    {
        if (countEnters == 0) return;
        var message = countEnters == 1 ? "1 person entered" : $"{countEnters} people entered";
        Messages.Add(message);
    }
    
    private void AddLeaveRoomMessage(int countLeave)
    {
        if (countLeave == 0) return;
        
        var message = $"{countLeave} left";
        
        Messages.Add(message);
    }
    
    private void AddCommentMessage(int countComment)
    {
        if (countComment == 0) return;
        
        var message = countComment == 1 ? $"1 comment" : $"{countComment} comments";
        Messages.Add(message);
    }
    
    private void AddHighFiveMessage(int countHighFive, int countUserReceived)
    {
        if (countHighFive == 0) return;
        
        var firstMessage = countHighFive == 1 ? $"1 person high-fived" : $"{countHighFive} people high-fived";
        var secondMessage = countUserReceived == 1 ? $"1 other person" : $"{countUserReceived} other people";
        
        Messages.Add($"{firstMessage}  {secondMessage}");
    }
}