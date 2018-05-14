using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiCountryRegionCurrencyModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionCurrencyModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionCurrencyModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>1bf02ff900c08589983e3ff9b0d0b6c8</Hash>
</Codenesium>*/