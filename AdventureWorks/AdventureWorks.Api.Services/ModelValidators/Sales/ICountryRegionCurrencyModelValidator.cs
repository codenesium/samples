using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiCountryRegionCurrencyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionCurrencyRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionCurrencyRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>262f99e0865787d3337a45a0f841e36b</Hash>
</Codenesium>*/