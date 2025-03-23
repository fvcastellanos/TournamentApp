using System.ComponentModel.DataAnnotations;

namespace TournamentApp.Domain.Views
{
    public class TournamentView
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }
        // public List<MatchView> Matches { get; set; }
    }
}