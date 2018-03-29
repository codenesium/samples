using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IPersonModelValidator
	{
		ValidationResult Validate(PersonModel entity);

		Task<ValidationResult> ValidateAsync(PersonModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>cd5195d414263708775b1047d19389aa</Hash>
</Codenesium>*/