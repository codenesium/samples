using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ProductReviewModelValidator: AbstractProductReviewModelValidator, IProductReviewModelValidator
	{
		public ProductReviewModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ProductReviewModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductReviewModel model)
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
    <Hash>ae2ede4197b0372fb902d01d826552ba</Hash>
</Codenesium>*/