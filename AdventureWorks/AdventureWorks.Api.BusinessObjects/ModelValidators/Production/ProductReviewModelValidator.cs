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
			this.ProductIDRules();
			this.ReviewerNameRules();
			this.ReviewDateRules();
			this.EmailAddressRules();
			this.RatingRules();
			this.CommentsRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductReviewModel model)
		{
			this.ProductIDRules();
			this.ReviewerNameRules();
			this.ReviewDateRules();
			this.EmailAddressRules();
			this.RatingRules();
			this.CommentsRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>45834768574b4b54c2158e5d7699fbd1</Hash>
</Codenesium>*/