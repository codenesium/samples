using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiCurrencyRateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCurrencyRateRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCurrencyRateRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>98e4376f0dd50c01d6ac357e3ce26058</Hash>
</Codenesium>*/