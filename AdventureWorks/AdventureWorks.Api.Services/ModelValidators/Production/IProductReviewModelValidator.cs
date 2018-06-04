using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
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
    <Hash>a5dc2933561e0e612b5e77c049699952</Hash>
</Codenesium>*/