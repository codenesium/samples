using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiTweetServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTweetServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTweetServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7250b1df411162dfbb31eca18c0c4cb2</Hash>
</Codenesium>*/