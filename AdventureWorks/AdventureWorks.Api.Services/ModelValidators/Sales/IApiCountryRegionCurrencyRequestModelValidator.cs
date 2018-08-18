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
    <Hash>36d3702415327924f15763eb70f71ee4</Hash>
</Codenesium>*/