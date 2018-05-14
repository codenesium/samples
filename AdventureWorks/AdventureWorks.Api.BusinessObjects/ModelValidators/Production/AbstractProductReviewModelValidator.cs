using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiProductReviewModelValidator: AbstractValidator<ApiProductReviewModel>
	{
		public new ValidationResult Validate(ApiProductReviewModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductReviewModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void CommentsRules()
		{
			this.RuleFor(x => x.Comments).Length(0, 3850);
		}

		public virtual void EmailAddressRules()
		{
			this.RuleFor(x => x.EmailAddress).NotNull();
			this.RuleFor(x => x.EmailAddress).Length(0, 50);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).NotNull();
		}

		public virtual void RatingRules()
		{
			this.RuleFor(x => x.Rating).NotNull();
		}

		public virtual void ReviewDateRules()
		{
			this.RuleFor(x => x.ReviewDate).NotNull();
		}

		public virtual void ReviewerNameRules()
		{
			this.RuleFor(x => x.ReviewerName).NotNull();
			this.RuleFor(x => x.ReviewerName).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>f42d1eff7ad387f16aef3f6e9aba9740</Hash>
</Codenesium>*/