using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiFollowingRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFollowingRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiFollowingRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>82bb5edd50c6c3fbe85e7dc07871f9d7</Hash>
</Codenesium>*/