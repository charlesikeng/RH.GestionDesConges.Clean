namespace RH.GestionDesConges.Application.Models.Email
{
	public class EmailSettings
	{
		public const string Key = "EmailSettings";
		public string SmtpHost { get; set; } = string.Empty;
		public int SmtpPort { get; set; }
		public string FromAddress { get; set; } = string.Empty;
		public string FromName { get; set; } = string.Empty;
	}
}
