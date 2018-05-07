using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IOrganizationModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(OrganizationModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, OrganizationModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d0bb76de17b3bb0a83f5f85c4e402290</Hash>
</Codenesium>*/