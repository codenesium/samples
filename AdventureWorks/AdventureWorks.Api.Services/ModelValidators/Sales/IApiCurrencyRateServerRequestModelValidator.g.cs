using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCurrencyRateServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCurrencyRateServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCurrencyRateServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>aed8b45d7c53e9c92a550b1d534d72d7</Hash>
</Codenesium>*/