using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GSWPlayerStatTracker.Models
{
    public class Player
    {
        [Display(Name = "Name")]
        public string? PlayerName { get; set; }

        public int? PlayerId { get; set; }
        [Display(Name = "Height")]
        public decimal? PlayerHeight { get; set; }

        public int? Age { get; set; }
        [Display(Name = "Points Per Game")]
        public int? PointsPerGame { get; set; }
        public string? Position { get; set; }
        public string? Photo { get; set; }

        
        
        
        // Parent
        public Team? Team { get; set; }
        [Display(Name = "Team Name")]
        public int TeamId { get; set; }

    }
}

