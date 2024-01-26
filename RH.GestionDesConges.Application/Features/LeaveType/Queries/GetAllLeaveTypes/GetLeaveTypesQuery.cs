using MediatR;

namespace RH.GestionDesConges.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
	public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;
}
