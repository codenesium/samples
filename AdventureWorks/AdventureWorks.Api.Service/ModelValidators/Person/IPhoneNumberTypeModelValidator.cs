using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IPhoneNumberTypeModelValidator
	{
		ValidationResult Validate(PhoneNumberTypeModel entity);

		Task<ValidationResult> ValidateAsync(PhoneNumberTypeModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>e4c6265448f36e8f25ab676004682423</Hash>
</Codenesium>*/