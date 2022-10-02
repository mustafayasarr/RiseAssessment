using Microsoft.EntityFrameworkCore;
using RiseAssessment.ContactService.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseAssessment.ContactService.Infrastructure.Context
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contact>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<ContactInformation>().HasQueryFilter(b => !b.IsDeleted);



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
