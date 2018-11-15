using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiCountryRegionServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCountryRegionServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCountryRegionServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>f159d5feb4c5a7aee579bcfd68b51260</Hash>
</Codenesium>*/