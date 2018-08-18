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
    <Hash>b52a2dc20401507c9786ec29d2f04743</Hash>
</Codenesium>*/