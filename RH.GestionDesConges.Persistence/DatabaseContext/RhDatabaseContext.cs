using Microsoft.EntityFrameworkCore;
using RH.GestionDesConges.Domain;
using RH.GestionDesConges.Domain.Common;

namespace RH.GestionDesConges.Persistence.DatabaseContext
{
	public class RhDatabaseContext : DbContext
	{
        public RhDatabaseContext(DbContextOptions<RhDatabaseContext> options) : base(options)
		{                
        }

		public DbSet<LeaveType> LeaveTypes { get; set; }
		public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
		public DbSet<LeaveRequest> LeaveRequests { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(RhDatabaseContext).Assembly);
			base.OnModelCreating(modelBuilder);
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
				.Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
			{
				entry.Entity.DateModified = DateTime.Now;

				if (entry.State == EntityState.Added)
				{
					entry.Entity.DateCreated = DateTime.Now;
				}
			}

			return base.SaveChangesAsync(cancellationToken);
		}
	}
}
