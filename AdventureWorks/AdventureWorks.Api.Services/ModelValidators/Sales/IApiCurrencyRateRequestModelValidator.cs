using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCurrencyRateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCurrencyRateRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCurrencyRateRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d4ae0221d66d6b80d2412d33626ccea6</Hash>
</Codenesium>*/