
namespace TournamentApp.Domain.Match;

public class Player
{
    public string Name { get; set; }
    public int Score { get; set; }
    public bool IsWinner { get; set; }
    public int Flags { get; set; }
}