using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiStateProvinceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStateProvinceRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateProvinceRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>13b383e05f1b52b54389957ff9b70f2c</Hash>
</Codenesium>*/