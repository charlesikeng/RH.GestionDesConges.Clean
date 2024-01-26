using MediatR;

namespace RH.GestionDesConges.Application.Features.LeaveType.Commands.DeleteLeaveType
{
	public class DeleteLeaveTypeCommand : IRequest<Unit>
	{
		public Guid Id { get; set; }
	}
}
