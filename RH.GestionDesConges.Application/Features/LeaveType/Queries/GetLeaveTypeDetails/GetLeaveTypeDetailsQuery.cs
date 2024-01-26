using MediatR;

namespace RH.GestionDesConges.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
	public record GetLeaveTypeDetailsQuery(Guid Id) : IRequest<LeaveTypeDetailDto>;
}
