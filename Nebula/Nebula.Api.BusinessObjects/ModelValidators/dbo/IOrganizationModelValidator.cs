using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiOrganizationModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOrganizationModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiOrganizationModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b358a94bcb1addd7921e62a04248a296</Hash>
</Codenesium>*/