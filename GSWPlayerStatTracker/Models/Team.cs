namespace GSWPlayerStatTracker.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string? TeamName { get; set; }
        public string? Location { get; set; }
        public string? TeamCreationYear { get; set; }

        //Child
        public List<Player>? Players { get; set; }
    }
}
