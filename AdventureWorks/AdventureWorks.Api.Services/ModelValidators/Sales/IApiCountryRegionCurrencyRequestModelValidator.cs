using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCountryRegionCurrencyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionCurrencyRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionCurrencyRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>192bdbb07c08f3f7905fb539ece73541</Hash>
</Codenesium>*/