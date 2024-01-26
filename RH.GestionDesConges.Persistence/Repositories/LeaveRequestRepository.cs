using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RH.GestionDesConges.Application.Contracts.Persistence;
using RH.GestionDesConges.Domain;
using RH.GestionDesConges.Persistence.DatabaseContext;

namespace RH.GestionDesConges.Persistence.Repositories
{
	public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
	{
		public LeaveRequestRepository(RhDatabaseContext context) : base(context)
		{
		}

		public async Task<LeaveRequest?> GetLeaveRequestWithDetails(Guid id)
		{
			var leaveRequest = await _context.LeaveRequests
				.Include(q => q.LeaveType)
				.FirstOrDefaultAsync(q => q.Id == id);

			return leaveRequest;
		}

		public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
		{
			var leaveRequests = await _context.LeaveRequests
				.Include(q => q.LeaveType)
				.ToListAsync();
			return leaveRequests;
		}

		public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
		{
			var leaveRequests = await _context.LeaveRequests
				.Where(q => q.RequestingEmployeeId == userId)
				.Include(q => q.LeaveType)
				.ToListAsync();

			return leaveRequests;
		}
	}
}
