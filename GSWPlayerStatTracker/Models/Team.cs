using System.ComponentModel.DataAnnotations;

namespace GSWPlayerStatTracker.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [Display(Name = "Team Name")]
        public string? TeamName { get; set; }
        public string? Location { get; set; }

        [Display(Name = "Establishment Year")]
        public string? TeamCreationYear { get; set; }

        //Child
        public List<Player>? Players { get; set; }
    }
}
