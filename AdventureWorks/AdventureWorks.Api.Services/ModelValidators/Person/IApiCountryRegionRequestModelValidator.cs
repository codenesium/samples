using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCountryRegionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>cba8658669c64791bdf838e2679473ee</Hash>
</Codenesium>*/