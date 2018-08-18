using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiLinkStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dbb0d994b2aff86f7801bebe96d77f71</Hash>
</Codenesium>*/