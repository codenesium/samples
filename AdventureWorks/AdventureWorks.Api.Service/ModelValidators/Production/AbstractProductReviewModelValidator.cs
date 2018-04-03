using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractProductReviewModelValidator: AbstractValidator<ProductReviewModel>
	{
		public new ValidationResult Validate(ProductReviewModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ProductReviewModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ProductIDRules()
		{
			RuleFor(x => x.ProductID).NotNull();
		}

		public virtual void ReviewerNameRules()
		{
			RuleFor(x => x.ReviewerName).NotNull();
			RuleFor(x => x.ReviewerName).Length(0,50);
		}

		public virtual void ReviewDateRules()
		{
			RuleFor(x => x.ReviewDate).NotNull();
		}

		public virtual void EmailAddressRules()
		{
			RuleFor(x => x.EmailAddress).NotNull();
			RuleFor(x => x.EmailAddress).Length(0,50);
		}

		public virtual void RatingRules()
		{
			RuleFor(x => x.Rating).NotNull();
		}

		public virtual void CommentsRules()
		{
			RuleFor(x => x.Comments).Length(0,3850);
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>816727714444f94798ae607fbc008aaa</Hash>
</Codenesium>*/