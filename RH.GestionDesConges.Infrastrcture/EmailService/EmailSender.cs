using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using RH.GestionDesConges.Application.Contracts.Email;
using RH.GestionDesConges.Application.Models.Email;

namespace RH.GestionDesConges.Infrastrcture.EmailService
{
	public class EmailSender : IEmailSender
	{
		public EmailSettings _emailSettings { get; }
		public EmailSender(IOptions<EmailSettings> emailSettings)
		{
			_emailSettings = emailSettings.Value;
		}


		public void SendEmail(EmailMessage email)
		{
			var emailMessage = new MimeMessage();
			emailMessage.From.Add(MailboxAddress.Parse(_emailSettings.FromAddress));
			emailMessage.To.Add(MailboxAddress.Parse(email.To));
			emailMessage.Subject = email.Subject;
			emailMessage.Body = new TextPart(TextFormat.Html) { Text = email.Body };

			using var smtp = new SmtpClient();
			smtp.Connect(_emailSettings.SmtpHost, _emailSettings.SmtpPort, SecureSocketOptions.None);
			var response = smtp.Send(emailMessage);
			smtp.Disconnect(true);
		}
	}
}
