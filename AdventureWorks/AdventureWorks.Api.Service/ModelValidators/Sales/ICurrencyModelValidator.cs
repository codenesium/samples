using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ICurrencyModelValidator
	{
		ValidationResult Validate(CurrencyModel entity);

		Task<ValidationResult> ValidateAsync(CurrencyModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>03bd9bf23d7eb4b178af23a57d67c197</Hash>
</Codenesium>*/