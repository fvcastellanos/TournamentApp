namespace TournamentApp.Domain.Match
{
    public class Score
    {
        public Judge Judge { get; set; }
        public int RedScore { get; set; }
        public int BlueScore { get; set; }

        public int RedFlags { get; set; }
        public int BlueFlags { get; set; }
    }
}