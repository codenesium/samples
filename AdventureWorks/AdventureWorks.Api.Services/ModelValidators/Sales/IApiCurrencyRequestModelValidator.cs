using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCurrencyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCurrencyRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCurrencyRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>78067ae197c5217b4785a93f7966a7dd</Hash>
</Codenesium>*/