
using TournamentApp.Domain.Match;

namespace TournamentApp.Services;

public class MatchService
{
    private readonly ILogger<MatchService> _logger;

    private MatchInformation _matchInformation;

    private IDictionary<string, Score> _scores;
    

    public MatchService(ILogger<MatchService> logger)
    {
        _logger = logger;
        _scores = new Dictionary<string, Score>();
    }

    public void CreateMatch(string matchName)
    {
        var match = new MatchInformation {
            MatchName = matchName,
            MatchId = Guid.NewGuid().ToString()
        };
    }

    public void StartMatch()
    {
        _logger.LogInformation("Match started");
    }

    public void EndMatch()
    {
        _logger.LogInformation("Match ended");
    }

    public void RegisterJudge(string judgeName)
    {
        var judge = new Judge { Name = judgeName };

        if (!_scores.ContainsKey(judgeName))
        {
            _scores.Add(judge.Name, new Score { Judge = judge });
            _logger.LogInformation($"Judge {judge.Name} registered");

            return;
        }

        _logger.LogWarning($"Judge {judge.Name} already registered");
    }


}
