using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IOrganizationModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(OrganizationModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, OrganizationModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cadc1e0014eabe1f234739a3b139b49d</Hash>
</Codenesium>*/