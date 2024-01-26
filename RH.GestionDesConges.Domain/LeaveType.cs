using System.Xml.Linq;
using RH.GestionDesConges.Domain.Common;

namespace RH.GestionDesConges.Domain
{
	public class LeaveType : BaseEntity
	{
		public string Name { get; set; } = string.Empty;
		public int DefaultDays { get; set; }

		public LeaveType(string name, int defaultDays) : this()
		{
			Id = Guid.NewGuid();
			Name = name;
			DefaultDays = defaultDays;
		}

		protected LeaveType()
		{
		}
	}


}
