﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace RH.GestionDesConges.Application.Features.LeaveType.Commands.CreateLeaveType
{
	public class CreateLeaveTypeCommand : IRequest<Guid>
	{
		public string Name { get; set; } = string.Empty;
		public int DefaultDays { get; set; }
	}
}
