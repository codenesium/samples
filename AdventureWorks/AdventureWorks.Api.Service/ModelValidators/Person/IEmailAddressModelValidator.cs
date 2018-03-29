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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>46278ef785afba9fbe929692671f1260</Hash>
</Codenesium>*/