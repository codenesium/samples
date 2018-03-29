using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IPersonPhoneModelValidator
	{
		ValidationResult Validate(PersonPhoneModel entity);

		Task<ValidationResult> ValidateAsync(PersonPhoneModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>11de98662a871343ae5d9677ec65ce04</Hash>
</Codenesium>*/