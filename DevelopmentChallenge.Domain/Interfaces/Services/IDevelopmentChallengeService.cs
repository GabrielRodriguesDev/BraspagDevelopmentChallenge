using DevelopmentChallenge.Domain.Command;

namespace DevelopmentChallenge.Domain.Interfaces.Services
{
    public interface IDevelopmentChallengeService
    {
        GenericCommandResult GetAll();
        GenericCommandResult calculateValue(DevelopmentChallengeCommand command);
    }
}