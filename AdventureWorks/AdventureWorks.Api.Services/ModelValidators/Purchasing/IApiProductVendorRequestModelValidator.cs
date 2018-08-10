using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductVendorRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductVendorRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductVendorRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d6ca86099a09436adc4b3628d5a47536</Hash>
</Codenesium>*/