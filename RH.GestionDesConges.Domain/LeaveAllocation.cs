using RH.GestionDesConges.Domain.Common;

namespace RH.GestionDesConges.Domain
{
	public class LeaveAllocation : BaseEntity
	{
		public int NumberOfDays { get; set; }
		public string EmployeedId { get; set; } = string.Empty;
		public LeaveType? LeaveType { get; set; }
		public Guid LeaveTypeId { get; set; }
		public int Period { get; set; }
	}
}
