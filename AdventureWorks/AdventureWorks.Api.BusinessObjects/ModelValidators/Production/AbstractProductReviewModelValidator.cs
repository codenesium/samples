using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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

		public IProductRepository ProductRepository { get; set; }
		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).NotNull();
			this.RuleFor(x => x.ProductID).Must(this.BeValidProduct).When(x => x ?.ProductID != null).WithMessage("Invalid reference");
		}

		public virtual void ReviewerNameRules()
		{
			this.RuleFor(x => x.ReviewerName).NotNull();
			this.RuleFor(x => x.ReviewerName).Length(0, 50);
		}

		public virtual void ReviewDateRules()
		{
			this.RuleFor(x => x.ReviewDate).NotNull();
		}

		public virtual void EmailAddressRules()
		{
			this.RuleFor(x => x.EmailAddress).NotNull();
			this.RuleFor(x => x.EmailAddress).Length(0, 50);
		}

		public virtual void RatingRules()
		{
			this.RuleFor(x => x.Rating).NotNull();
		}

		public virtual void CommentsRules()
		{
			this.RuleFor(x => x.Comments).Length(0, 3850);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidProduct(int id)
		{
			return this.ProductRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>86c16e02b6516ade8594b02a3d92904f</Hash>
</Codenesium>*/