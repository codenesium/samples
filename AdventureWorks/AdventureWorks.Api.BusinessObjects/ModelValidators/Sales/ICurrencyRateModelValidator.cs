using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiCurrencyRateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCurrencyRateRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCurrencyRateRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8a2d8257458e1bc4b8903e8818493c92</Hash>
</Codenesium>*/