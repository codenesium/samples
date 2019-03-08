using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostsServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostsServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostsServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5c25b2462440a5616dbb441fccfd0133</Hash>
</Codenesium>*/