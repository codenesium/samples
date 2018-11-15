using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiBillOfMaterialServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBillOfMaterialServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBillOfMaterialServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9a6b6be0a963483570d039b9ba4499b9</Hash>
</Codenesium>*/