using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public interface IApiLinkRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>481217a9a23bb0503a0ce93bcd71febb</Hash>
</Codenesium>*/