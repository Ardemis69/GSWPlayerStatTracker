using System.ComponentModel.DataAnnotations.Schema;

namespace GSWPlayerStatTracker.Models
{
    public class Player
    {
        public string? PlayerName { get; set; }
        public int? PlayerId { get; set; }
        public decimal? PlayerHeight { get; set; }
        public int? Age { get; set; }
        public int? PointsPerGame { get; set; }
        public string? Position { get; set; }
        public string? Photo { get; set; }

        
        
        
        // Parent
        public Team? Team { get; set; }
        public string? TeamName { get; set; }

    }
}

