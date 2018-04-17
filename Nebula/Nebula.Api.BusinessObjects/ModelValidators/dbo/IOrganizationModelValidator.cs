using System;
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
    <Hash>ea5d1f1677ab34b05df182f2d8e710b0</Hash>
</Codenesium>*/