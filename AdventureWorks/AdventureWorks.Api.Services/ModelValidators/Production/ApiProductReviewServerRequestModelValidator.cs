using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductReviewServerRequestModelValidator : AbstractApiProductReviewServerRequestModelValidator, IApiProductReviewServerRequestModelValidator
	{
		public ApiProductReviewServerRequestModelValidator(IProductReviewRepository productReviewRepository)
			: base(productReviewRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductReviewServerRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductReviewServerRequestModel model)
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
    <Hash>ab1ba1d4fb608c1458ec901f1f207f3a</Hash>
</Codenesium>*/