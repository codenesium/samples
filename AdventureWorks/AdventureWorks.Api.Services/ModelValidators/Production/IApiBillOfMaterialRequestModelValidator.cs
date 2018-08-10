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
    <Hash>44ee179cefda2603c6287812645808aa</Hash>
</Codenesium>*/