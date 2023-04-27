using PowerDiaryChallenge.Commands.Handlers;
using PowerDiaryChallenge.Commands;
using PowerDiaryChallenge.Commands.Dispatchers;
using PowerDiaryChallenge.Queries;
using PowerDiaryChallenge.Queries.Dispatchers;
using PowerDiaryChallenge.Queries.Handlers;
using PowerDiaryChallenge.Queries.Responses;
using PowerDiaryChallenge.Repositories;

namespace PowerDiaryChallenge.Api.IoC;
public static class IoCContainer
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddTransient<ICommandHandler<CommentCommand>, CommentCommandHandler>();
        services.AddTransient<ICommandHandler<HighFiveAnotherUserCommand>, HighFiveAnotherUserCommandHandler>();
        services.AddTransient<ICommandHandler<EnterRoomCommand>, EnterRoomCommandHandler>();
        services.AddTransient<ICommandHandler<LeaveRoomCommand>, LeaveRoomCommandHandler>();
        
        services.AddTransient<IQueryHandler<GetChatEventHourlyQuery, GetChatEventHourlyResponse>, GetChatEventHourlyQueryHandler>();
        services.AddTransient<IQueryHandler<GetChatEventMinutelyQuery, GetChatEventMinutelyResponse>, GetChatEventMinutelyQueryHandler>();
        
        services.AddTransient<ICommandDispatcher, CommandDispatcher>();
        services.AddTransient<IQueryDispatcher, QueryDispatcher>();

        return services;
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IChatEventRepository, ChatEventInMemoryRepository>();
        return services;
    }

}