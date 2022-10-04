using Microsoft.EntityFrameworkCore;
using RiseAssessment.ReportService.Domain.Models.Entities;

namespace RiseAssessment.ReportService.Infrastructure.Context
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        {
                            if (entry.Entity.CreatedAtUTC == DateTime.MinValue)
                            {
                                entry.Entity.CreatedAtUTC = DateTime.UtcNow;
                                entry.Entity.IsDeleted = false;
                            }
                            break;
                        }

                    case EntityState.Modified:
                        {
                            if (entry.Entity.ModifiedAtUTC == null)
                            {
                                entry.Entity.ModifiedAtUTC = DateTime.UtcNow;
                            }
                            break;
                        }
                    case EntityState.Deleted:
                        {
                            entry.State = EntityState.Modified;
                            entry.Entity.IsDeleted = true;
                            if (entry.Entity.ModifiedAtUTC == null)
                            {
                                entry.Entity.ModifiedAtUTC = DateTime.UtcNow;
                            }
                            break;
                        }

                }
            }
            return base.SaveChangesAsync(cancellationToken);

        }
    }
}
