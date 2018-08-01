using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public interface IApiPostsRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostsRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostsRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ef72dee75134d73a903db55f4698ea4b</Hash>
</Codenesium>*/