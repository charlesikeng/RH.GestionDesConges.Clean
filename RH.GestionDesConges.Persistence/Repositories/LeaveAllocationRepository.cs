using Microsoft.EntityFrameworkCore;
using RH.GestionDesConges.Application.Contracts.Persistence;
using RH.GestionDesConges.Domain;
using RH.GestionDesConges.Persistence.DatabaseContext;

namespace RH.GestionDesConges.Persistence.Repositories
{
	public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
	{
		public LeaveAllocationRepository(RhDatabaseContext context) : base(context)
		{
		}

		public async Task AddAllocations(List<LeaveAllocation> allocations)
		{
			await _context.AddRangeAsync(allocations);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> AllocationExists(string userId, Guid leaveTypeId, int period)
		{
			return await _context.LeaveAllocations.AnyAsync(q => q.EmployeedId == userId
									&& q.LeaveTypeId == leaveTypeId
									&& q.Period == period);
		}

		public async Task<LeaveAllocation?> GetLeaveAllocationWithDetails(Guid id)
		{
			var leaveAllocation = await _context.LeaveAllocations
				.Include(q => q.LeaveType)
				.FirstOrDefaultAsync(q => q.Id == id);

			return leaveAllocation;
		}

		public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
		{
			var leaveAllocations = await _context.LeaveAllocations
				.Include(q => q.LeaveType)
				.ToListAsync();
			return leaveAllocations;
		}

		public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
		{
			var leaveAllocations = await _context.LeaveAllocations.Where(q => q.EmployeedId ==
			userId)
				.Include(q => q.LeaveType)
				.ToListAsync();
			return leaveAllocations;
		}

		public async Task<LeaveAllocation?> GetUserAllocations(string userId, Guid leaveTypeId)
		{
			var leaveAllocation = await _context.LeaveAllocations
				.Include(q => q.LeaveType)
				.FirstOrDefaultAsync(q => q.EmployeedId == userId
				&& q.LeaveTypeId == leaveTypeId);

			return leaveAllocation;
		}
	}
}
