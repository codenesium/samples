using System.Threading.Tasks;
using FluentValidation.Results;

using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.Service
{
	public interface IOrganizationModelValidator
	{
		ValidationResult Validate(OrganizationModel entity);

		Task<ValidationResult> ValidateAsync(OrganizationModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>d507b483ed98af42dc06b6436fa5890c</Hash>
</Codenesium>*/