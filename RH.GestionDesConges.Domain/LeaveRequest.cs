﻿using System.Xml.Linq;
using RH.GestionDesConges.Domain.Common;

namespace RH.GestionDesConges.Domain
{
	public class LeaveRequest : BaseEntity
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		public LeaveType? LeaveType { get; set; }
		public Guid LeaveTypeId { get; set; }

		public DateTime DateRequested { get; set; }
		public string? RequestComments { get; set; }

		public bool? Approved { get; set; }
		public bool Cancelled { get; set; }

		public string RequestingEmployeeId { get; set; } = string.Empty;

	}
}
