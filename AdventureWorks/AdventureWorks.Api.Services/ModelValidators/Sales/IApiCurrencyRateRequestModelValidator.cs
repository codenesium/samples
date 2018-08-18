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
    <Hash>e14ff0ae49092ce88744142db9b9c719</Hash>
</Codenesium>*/