using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiBillOfMaterialsRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBillOfMaterialsRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBillOfMaterialsRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4dbc8e5d34900ac4c1b4d225e61107b0</Hash>
</Codenesium>*/