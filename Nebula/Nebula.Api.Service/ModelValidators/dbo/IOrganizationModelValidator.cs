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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>ad52a5dcac6948e956dba11f4f2967a9</Hash>
</Codenesium>*/