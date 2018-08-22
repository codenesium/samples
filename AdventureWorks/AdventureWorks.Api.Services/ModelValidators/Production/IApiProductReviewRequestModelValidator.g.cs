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
    <Hash>9cc3071f344553b256a364897f9b111e</Hash>
</Codenesium>*/