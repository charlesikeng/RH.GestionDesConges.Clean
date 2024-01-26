using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RH.GestionDesConges.Application.Contracts.Email;
using RH.GestionDesConges.Application.Contracts.Logging;
using RH.GestionDesConges.Application.Models.Email;
using RH.GestionDesConges.Infrastrcture.EmailService;
using RH.GestionDesConges.Infrastrcture.Logging;

namespace RH.GestionDesConges.Infrastrcture
{
	public static class InfrastructureServiceRegistration
	{
		public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,
			IConfiguration config)
		{
			services.Configure<EmailSettings>(config.GetSection(EmailSettings.Key));
			services.AddTransient<IEmailSender, EmailSender>();
			services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

			return services;
		}
	}
}
