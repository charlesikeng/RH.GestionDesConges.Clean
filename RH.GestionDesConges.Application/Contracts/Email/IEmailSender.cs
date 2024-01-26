using RH.GestionDesConges.Application.Models.Email;

namespace RH.GestionDesConges.Application.Contracts.Email
{
	public interface IEmailSender
	{
		void SendEmail(EmailMessage email);
	}
}
