using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IPersonCreditCardModelValidator
	{
		ValidationResult Validate(PersonCreditCardModel entity);

		Task<ValidationResult> ValidateAsync(PersonCreditCardModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>9f0b664dcaed5e3da8d0d24f54df8c7e</Hash>
</Codenesium>*/