using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiTweetRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTweetRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTweetRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2ab24e8e409b7179c4277cf88af2699c</Hash>
</Codenesium>*/