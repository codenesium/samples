using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
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
    <Hash>d7b0608ac296933cee1c04b53764ea2a</Hash>
</Codenesium>*/