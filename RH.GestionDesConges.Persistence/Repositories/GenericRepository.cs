using Microsoft.EntityFrameworkCore;
using RH.GestionDesConges.Application.Contracts.Persistence;
using RH.GestionDesConges.Domain.Common;
using RH.GestionDesConges.Persistence.DatabaseContext;

namespace RH.GestionDesConges.Persistence.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		protected readonly RhDatabaseContext _context;

		public GenericRepository(RhDatabaseContext context)
		{
			this._context = context;
		}
		public async Task CreateAsync(T entity)
		{
			await _context.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			_context.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<IReadOnlyList<T>> GetAsync()
		{
			return await _context.Set<T>().AsNoTracking().ToListAsync();
		}

		public async Task<T> GetByIdAsync(Guid id)
		{
			return await _context.Set<T>()
				.AsNoTracking()
				.FirstOrDefaultAsync(q => q.Id == id);
		}

		public async Task UpdateAsync(T entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
