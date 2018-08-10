using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostsRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostsRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostsRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>199949a9683cbf48cfe3c718b883b714</Hash>
</Codenesium>*/