using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductReviewRequestModelValidator : AbstractApiProductReviewRequestModelValidator, IApiProductReviewRequestModelValidator
	{
		public ApiProductReviewRequestModelValidator(IProductReviewRepository productReviewRepository)
			: base(productReviewRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductReviewRequestModel model)
		{
			this.CommentRules();
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
			this.CommentRules();
			this.EmailAddressRules();
			this.ModifiedDateRules();
			this.ProductIDRules();
			this.RatingRules();
			this.ReviewDateRules();
			this.ReviewerNameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>85b6eda4f2f33cc193937b077e7b4b77</Hash>
</Codenesium>*/