using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductModelRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModelRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8b9350ff90b601b0e24c0f8d2395389e</Hash>
</Codenesium>*/