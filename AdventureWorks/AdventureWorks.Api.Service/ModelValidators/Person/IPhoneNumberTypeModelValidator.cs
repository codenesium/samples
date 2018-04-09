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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>2f87674e2d44342f4590eb238332dd27</Hash>
</Codenesium>*/