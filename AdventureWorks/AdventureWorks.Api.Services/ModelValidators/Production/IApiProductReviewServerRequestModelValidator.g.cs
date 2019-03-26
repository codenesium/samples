using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductReviewServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductReviewServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductReviewServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>eebaed2ee85f542fa955495de0d989de</Hash>
</Codenesium>*/