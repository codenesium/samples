using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductReviewRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductReviewRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductReviewRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a1ec857b436caca500343998efe31f21</Hash>
</Codenesium>*/