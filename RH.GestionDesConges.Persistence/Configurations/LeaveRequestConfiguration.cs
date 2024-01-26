using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RH.GestionDesConges.Domain;

namespace RH.GestionDesConges.Persistence.Configurations
{
	public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
	{
		public void Configure(EntityTypeBuilder<LeaveRequest> builder)
		{
			builder.ToTable(nameof(LeaveRequest));
			builder.HasKey(c => c.Id);
		}
	}
}
