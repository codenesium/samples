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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>acfdcb3e80e804bec3ec55f2468ead6f</Hash>
</Codenesium>*/