using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RH.GestionDesConges.Domain;

namespace RH.GestionDesConges.Persistence.Configurations
{
	public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
	{
		public void Configure(EntityTypeBuilder<LeaveType> builder)
		{
			builder.ToTable(nameof(LeaveType));
			builder.HasKey(c => c.Id);

			builder.HasData(
				new LeaveType("Vacation",10)
				);

			builder.Property(q => q.Name)
				.IsRequired()
				.HasMaxLength(100);
		}
	}
}
