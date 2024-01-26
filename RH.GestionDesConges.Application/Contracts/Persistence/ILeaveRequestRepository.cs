using RH.GestionDesConges.Domain;

namespace RH.GestionDesConges.Application.Contracts.Persistence
{
	public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
	{
		Task<LeaveRequest?> GetLeaveRequestWithDetails(Guid id);
		Task<List<LeaveRequest>> GetLeaveRequestWithDetails();
		Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId);
	}
}
