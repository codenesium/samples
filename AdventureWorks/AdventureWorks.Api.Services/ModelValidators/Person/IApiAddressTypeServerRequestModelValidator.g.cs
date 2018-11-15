using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiAddressTypeServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAddressTypeServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressTypeServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a8738fa31b1ae7a80a5c4941d28365e6</Hash>
</Codenesium>*/