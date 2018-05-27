using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiCountryRegionCurrencyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionCurrencyRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionCurrencyRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>a8662311151c9c1b3ac7cee4d42c4080</Hash>
</Codenesium>*/