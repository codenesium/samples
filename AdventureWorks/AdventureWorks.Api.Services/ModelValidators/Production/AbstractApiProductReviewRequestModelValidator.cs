using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductReviewRequestModelValidator : AbstractValidator<ApiProductReviewRequestModel>
	{
		private int existingRecordId;

		private IProductReviewRepository productReviewRepository;

		public AbstractApiProductReviewRequestModelValidator(IProductReviewRepository productReviewRepository)
		{
			this.productReviewRepository = productReviewRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductReviewRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CommentRules()
		{
			this.RuleFor(x => x.Comment).Length(0, 3850);
		}

		public virtual void EmailAddressRules()
		{
			this.RuleFor(x => x.EmailAddress).NotNull();
			this.RuleFor(x => x.EmailAddress).Length(0, 50);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void ProductIDRules()
		{
		}

		public virtual void RatingRules()
		{
		}

		public virtual void ReviewDateRules()
		{
		}

		public virtual void ReviewerNameRules()
		{
			this.RuleFor(x => x.ReviewerName).NotNull();
			this.RuleFor(x => x.ReviewerName).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>f3cfc573bde6c773bd467ef4c58cfab1</Hash>
</Codenesium>*/