using Microsoft.EntityFrameworkCore;
using RH.GestionDesConges.Application.Contracts.Persistence;
using RH.GestionDesConges.Domain;
using RH.GestionDesConges.Persistence.DatabaseContext;

namespace RH.GestionDesConges.Persistence.Repositories
{
	public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
	{
		public LeaveTypeRepository(RhDatabaseContext context) : base(context)
		{
		}

		public async Task<bool> IsLeaveTypeUnique(string name)
		{
			return await _context.LeaveTypes.AnyAsync(x => x.Name == name);
		}
	}
}
