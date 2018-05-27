using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiProductReviewRequestModelValidator: AbstractApiProductReviewRequestModelValidator, IApiProductReviewRequestModelValidator
	{
		public ApiProductReviewRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductReviewRequestModel model)
		{
			this.CommentsRules();
			this.EmailAddressRules();
			this.ModifiedDateRules();
			this.ProductIDRules();
			this.RatingRules();
			this.ReviewDateRules();
			this.ReviewerNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductReviewRequestModel model)
		{
			this.CommentsRules();
			this.EmailAddressRules();
			this.ModifiedDateRules();
			this.ProductIDRules();
			this.RatingRules();
			this.ReviewDateRules();
			this.ReviewerNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>964b61889e29bef82de6a127479cd7ac</Hash>
</Codenesium>*/