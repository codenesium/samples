using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiDirectTweetRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDirectTweetRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDirectTweetRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4b4f32f066fee16ce797cc8d2952539a</Hash>
</Codenesium>*/