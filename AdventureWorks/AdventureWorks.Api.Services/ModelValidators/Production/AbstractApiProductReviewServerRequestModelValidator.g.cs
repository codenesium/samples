using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiProductReviewServerRequestModelValidator : AbstractValidator<ApiProductReviewServerRequestModel>
	{
		private int existingRecordId;

		private IProductReviewRepository productReviewRepository;

		public AbstractApiProductReviewServerRequestModelValidator(IProductReviewRepository productReviewRepository)
		{
			this.productReviewRepository = productReviewRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductReviewServerRequestModel model, int id)
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
    <Hash>9dc940012b3b7e306cfc659ac02a18fb</Hash>
</Codenesium>*/