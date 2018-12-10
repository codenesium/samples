using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractApiQuoteTweetServerRequestModelValidator : AbstractValidator<ApiQuoteTweetServerRequestModel>
	{
		private int existingRecordId;

		protected IQuoteTweetRepository QuoteTweetRepository { get; private set; }

		public AbstractApiQuoteTweetServerRequestModelValidator(IQuoteTweetRepository quoteTweetRepository)
		{
			this.QuoteTweetRepository = quoteTweetRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiQuoteTweetServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ContentRules()
		{
			this.RuleFor(x => x.Content).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Content).Length(0, 140).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void DateRules()
		{
		}

		public virtual void RetweeterUserIdRules()
		{
			this.RuleFor(x => x.RetweeterUserId).MustAsync(this.BeValidUserByRetweeterUserId).When(x => !x?.RetweeterUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void SourceTweetIdRules()
		{
			this.RuleFor(x => x.SourceTweetId).MustAsync(this.BeValidTweetBySourceTweetId).When(x => !x?.SourceTweetId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void TimeRules()
		{
		}

		protected async Task<bool> BeValidUserByRetweeterUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.QuoteTweetRepository.UserByRetweeterUserId(id);

			return record != null;
		}

		protected async Task<bool> BeValidTweetBySourceTweetId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.QuoteTweetRepository.TweetBySourceTweetId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>917c8c87f0b6bfb050b9803fd3a3e9fb</Hash>
</Codenesium>*/