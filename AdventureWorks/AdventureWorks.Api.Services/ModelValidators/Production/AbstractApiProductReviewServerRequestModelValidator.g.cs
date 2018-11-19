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
			this.RuleFor(x => x.Comment).Length(0, 3850).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void EmailAddressRules()
		{
			this.RuleFor(x => x.EmailAddress).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.EmailAddress).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
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
			this.RuleFor(x => x.ReviewerName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.ReviewerName).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>bba429ccc562d767870eefdd3a15f5da</Hash>
</Codenesium>*/