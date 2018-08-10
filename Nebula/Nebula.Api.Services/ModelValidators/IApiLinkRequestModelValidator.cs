using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiLinkRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a8fbd8739302b3d2e201be3f0c0c52b7</Hash>
</Codenesium>*/