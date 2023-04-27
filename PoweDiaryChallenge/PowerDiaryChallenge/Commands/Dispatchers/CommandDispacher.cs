using Microsoft.Extensions.DependencyInjection;
using PowerDiaryChallenge.Commands.Handlers;

namespace PowerDiaryChallenge.Commands.Dispatchers;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceFactory)
    {
        _serviceProvider = serviceFactory;
    }

    public void Send<T>(T command) where T : class
    {
        var handler = _serviceProvider.GetRequiredService<ICommandHandler<T>>();

        handler.Handle(command);
    }
}