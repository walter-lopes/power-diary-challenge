namespace PowerDiaryChallenge.Commands.Handlers;

public interface ICommandHandler<in T> where T : class
{
    void Handle(T command);
}