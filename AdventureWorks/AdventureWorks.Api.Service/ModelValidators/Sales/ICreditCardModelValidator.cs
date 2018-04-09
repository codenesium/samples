using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ICreditCardModelValidator
	{
		ValidationResult Validate(CreditCardModel entity);

		Task<ValidationResult> ValidateAsync(CreditCardModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>7e595b31aa4baf53d2a8a311614054ad</Hash>
</Codenesium>*/