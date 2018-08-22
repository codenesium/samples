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
    <Hash>552a115e893714484580250dc9ed868c</Hash>
</Codenesium>*/