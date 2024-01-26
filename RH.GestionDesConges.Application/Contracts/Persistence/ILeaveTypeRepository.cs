using RH.GestionDesConges.Domain;

namespace RH.GestionDesConges.Application.Contracts.Persistence
{
	public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
	{
		Task<bool> IsLeaveTypeUnique(string name);
	}
}
