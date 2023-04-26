using PowerDiaryChallenge.Queries.Responses;
using PowerDiaryChallenge.Repositories;

namespace PowerDiaryChallenge.Queries.Handlers;

public class GetChatEventMinutelyQueryHandler : IQueryHandler<GetChatEventMinutelyQuery, GetChatEventMinutelyResponse>
{
    private readonly IChatEventRepository _chatEventRepository;

    public GetChatEventMinutelyQueryHandler(IChatEventRepository chatEventRepository)
    {
        _chatEventRepository = chatEventRepository;
    }

    public GetChatEventMinutelyResponse Handle(GetChatEventMinutelyQuery query)
    {
        var events = _chatEventRepository.GetByPeriod(query.Start, query.End);

        return new GetChatEventMinutelyResponse(events);
    }
}