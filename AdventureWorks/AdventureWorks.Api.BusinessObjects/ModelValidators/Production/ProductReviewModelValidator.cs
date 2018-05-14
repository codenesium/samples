using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiProductReviewModelValidator: AbstractApiProductReviewModelValidator, IApiProductReviewModelValidator
	{
		public ApiProductReviewModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductReviewModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductReviewModel model)
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
    <Hash>9dc5a596d824c4dffe9fe7bdf9cfeae2</Hash>
</Codenesium>*/