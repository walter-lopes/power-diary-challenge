namespace PowerDiaryChallenge.Commands.Dispatchers;

public interface ICommandDispatcher
{
    void Send<T>(T command) where T : class;
}