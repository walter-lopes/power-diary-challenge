using PowerDiaryChallenge.Queries.Responses;
using PowerDiaryChallenge.Repositories;

namespace PowerDiaryChallenge.Queries.Handlers;

public class GetChatEventHourlyQueryHandler : IQueryHandler<GetChatEventHourlyQuery, GetChatEventHourlyResponse>
{
    private readonly IChatEventRepository _chatEventRepository;

    public GetChatEventHourlyQueryHandler(IChatEventRepository chatEventRepository)
    {
        _chatEventRepository = chatEventRepository;
    }
    
    public GetChatEventHourlyResponse Handle(GetChatEventHourlyQuery query)
    {
        var events = _chatEventRepository.GetByPeriod(query.Start, query.End);

        return new GetChatEventHourlyResponse(events);
    }
}