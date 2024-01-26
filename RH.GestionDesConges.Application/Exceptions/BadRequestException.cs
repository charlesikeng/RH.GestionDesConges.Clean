using FluentValidation.Results;

namespace RH.GestionDesConges.Application.Exceptions
{
	public class BadRequestException : Exception
	{
		public BadRequestException(string message) : base(message)
		{

		}

		public BadRequestException(string message, ValidationResult validationResult) : this(message)
		{
			ValidationErrors = new();

			foreach (var error in validationResult.Errors)
			{
				ValidationErrors.Add(error.ErrorMessage);

			}
		}

		public List<string> ValidationErrors { get; set; }
	}
}
