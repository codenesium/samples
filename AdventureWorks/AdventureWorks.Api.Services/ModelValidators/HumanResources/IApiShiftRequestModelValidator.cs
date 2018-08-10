using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiShiftRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShiftRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShiftRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f09b27d044283c03b0d30748ef6d5dcc</Hash>
</Codenesium>*/