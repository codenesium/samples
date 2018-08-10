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
    <Hash>79218ddb7de73d703fe055e88bb390ed</Hash>
</Codenesium>*/