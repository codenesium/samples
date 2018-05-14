using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiCurrencyRateModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCurrencyRateModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCurrencyRateModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>13ea1be32dda2bcdc38252422165fc51</Hash>
</Codenesium>*/