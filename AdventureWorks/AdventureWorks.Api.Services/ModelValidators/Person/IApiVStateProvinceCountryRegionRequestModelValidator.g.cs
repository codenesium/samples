using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiVStateProvinceCountryRegionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVStateProvinceCountryRegionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVStateProvinceCountryRegionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3b84080276a2ca8270102469e355f379</Hash>
</Codenesium>*/