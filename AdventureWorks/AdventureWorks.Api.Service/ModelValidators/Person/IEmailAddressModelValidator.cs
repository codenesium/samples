using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IEmailAddressModelValidator
	{
		ValidationResult Validate(EmailAddressModel entity);

		Task<ValidationResult> ValidateAsync(EmailAddressModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>60821cbb5a41e8b96ef87580c40de071</Hash>
</Codenesium>*/