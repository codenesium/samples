using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostLinkRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostLinkRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostLinkRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d47b429d83cc57762963ad95222531fe</Hash>
</Codenesium>*/