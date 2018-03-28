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
    <Hash>3e0e9f19ad21816a727e16f0711560f8</Hash>
</Codenesium>*/