using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiBillOfMaterialRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBillOfMaterialRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBillOfMaterialRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9d94900e7356f50636ced9088a53c562</Hash>
</Codenesium>*/