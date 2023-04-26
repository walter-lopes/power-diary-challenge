namespace PowerDiaryChallenge.Commands.Dispachers;

public interface ICommandDispatcher
{
    void Send<T>(T command) where T : class;
}