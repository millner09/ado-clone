using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<WorkItemState> WorkItemStates { get; set; }
    }
}
