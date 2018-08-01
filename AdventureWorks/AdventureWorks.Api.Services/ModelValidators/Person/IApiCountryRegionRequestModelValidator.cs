using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiCountryRegionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>0e25c5c62100e7b0f123d43fc30972db</Hash>
</Codenesium>*/