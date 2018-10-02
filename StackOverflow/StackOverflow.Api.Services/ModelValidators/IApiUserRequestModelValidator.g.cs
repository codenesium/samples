using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiUserRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUserRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiUserRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f6ffa79a1b69971b477d95effcf9af19</Hash>
</Codenesium>*/