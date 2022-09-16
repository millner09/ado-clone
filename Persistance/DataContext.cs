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
        public DbSet<WorkItemType> WorkItemTypes { get; set; }
        public DbSet<WorkItemState> WorkItemStates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userStoryId = Guid.NewGuid();
            var workItemId = Guid.NewGuid();
            var baseWorkItemStateId = Guid.NewGuid();

            modelBuilder.Entity<WorkItemType>()
            .HasData(
                new WorkItemType
                {
                    Id = userStoryId,
                    Name = "User Story",
                }
            );

            modelBuilder.Entity<WorkItemState>()
            .HasData(
                new WorkItemState
                {
                    Id = baseWorkItemStateId,
                    Name = "New",
                    WorkItemBaseState = WorkItemBaseState.PROPOSED,
                    WorkItemTypeId = userStoryId
                },
                new WorkItemState
                {
                    Id = Guid.NewGuid(),
                    Name = "Active",
                    WorkItemBaseState = WorkItemBaseState.INPROGRESS,
                    WorkItemTypeId = userStoryId
                }, new WorkItemState
                {
                    Id = Guid.NewGuid(),
                    Name = "Resolved",
                    WorkItemBaseState = WorkItemBaseState.INPROGRESS,
                    WorkItemTypeId = userStoryId
                }, new WorkItemState
                {
                    Id = Guid.NewGuid(),
                    Name = "Closed",
                    WorkItemBaseState = WorkItemBaseState.COMPLETED,
                    WorkItemTypeId = userStoryId
                },
                new WorkItemState
                {
                    Id = Guid.NewGuid(),
                    Name = "Removed",
                    WorkItemBaseState = WorkItemBaseState.REMOVED,
                    WorkItemTypeId = userStoryId
                }
            );

            modelBuilder.Entity<WorkItem>()
                .HasData(
                    new WorkItem
                    {
                        Id = workItemId,
                        WorkItemTypeId = userStoryId,
                        Title = "Seed User Story in Database",
                        WorkItemStateId = baseWorkItemStateId
                    }
                );
        }
    }
}
