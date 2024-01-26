using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RH.GestionDesConges.Domain;

namespace RH.GestionDesConges.Persistence.Configurations
{
	public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
	{
		public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
		{
			builder.ToTable(nameof(LeaveAllocation));
			builder.HasKey(c => c.Id);
		}
	}
}
