using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RH.GestionDesConges.Application.Contracts.Persistence;
using RH.GestionDesConges.Persistence.DatabaseContext;
using RH.GestionDesConges.Persistence.Repositories;

namespace RH.GestionDesConges.Persistence
{
	public static class PersistenceServiceRegistration
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
	IConfiguration configuration)
		{
			services.AddDbContext<RhDatabaseContext>(options => {
				options.UseSqlServer(configuration.GetConnectionString("RhDatabaseConnectionString"));
			});


			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
			services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
			services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();

			return services;
		}
	}
}
