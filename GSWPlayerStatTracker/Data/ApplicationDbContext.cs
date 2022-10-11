using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GSWPlayerStatTracker.Models;

namespace GSWPlayerStatTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GSWPlayerStatTracker.Models.Player> Players { get; set; }
        public DbSet<GSWPlayerStatTracker.Models.Team> Teams { get; set; }
    }
}