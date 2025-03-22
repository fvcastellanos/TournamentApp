namespace TournamentApp.Domain.Match;

public class MatchInformation
{
    public string MatchId { get; set; }
    public string MatchName { get; set; }
    public Player RedPlayer { get; set; }
    public Player BluePlayer { get; set; }
    public Player Winner { get; set; }
    public Player Loser { get; set; }
    public IEnumerable<Judge> Judges { get; set; }
    public string Tournament { get; set; }
    public string Round { get; set; }
    public int RoundTimer { get; set; }
    public string MatchTime { get; set; }
    public string MatchDate { get; set; }
    public string MatchLocation { get; set; }
    public string MatchType { get; set; }
}
