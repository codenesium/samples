using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductReviewRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductReviewRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductReviewRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3ce490f1b9f61559de464469dd2af51e</Hash>
</Codenesium>*/