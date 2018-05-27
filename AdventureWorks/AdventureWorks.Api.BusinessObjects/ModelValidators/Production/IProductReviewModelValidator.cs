using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductReviewRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductReviewRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductReviewRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>772bc74e87c692fa7c42db53d622a312</Hash>
</Codenesium>*/