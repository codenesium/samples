using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public interface IApiLinkLogRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkLogRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkLogRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f8cbca94f3917eb690026644b5aba1ef</Hash>
</Codenesium>*/