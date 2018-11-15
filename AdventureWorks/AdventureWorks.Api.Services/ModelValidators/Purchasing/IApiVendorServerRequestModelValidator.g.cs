using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiVendorServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVendorServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVendorServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b4c2d1b08b947123313257e4a17a3c0b</Hash>
</Codenesium>*/