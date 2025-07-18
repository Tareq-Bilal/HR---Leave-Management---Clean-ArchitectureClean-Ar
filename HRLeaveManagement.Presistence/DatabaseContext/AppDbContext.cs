using HRLeaveManagement.Domain;
using HRLeaveManagement.Domain.Common;
using HRLeaveManagement.Presistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Presistence.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveRequest> LeaveRequests{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            
            // One Line Configuration Method
            modelBuilder.ApplyConfiguration(new LeaveTypeConfiguration());
            
            base.OnModelCreating(modelBuilder);

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {

                item.Entity.DateModified = DateTime.Now;

                if (item.State == EntityState.Added)
                {
                    item.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
