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
	public abstract class AbstractApiTweetServerRequestModelValidator : AbstractValidator<ApiTweetServerRequestModel>
	{
		private int existingRecordId;

		protected ITweetRepository TweetRepository { get; private set; }

		public AbstractApiTweetServerRequestModelValidator(ITweetRepository tweetRepository)
		{
			this.TweetRepository = tweetRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTweetServerRequestModel model, int id)
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

		public virtual void LocationIdRules()
		{
			this.RuleFor(x => x.LocationId).MustAsync(this.BeValidLocationByLocationId).When(x => !x?.LocationId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void TimeRules()
		{
		}

		public virtual void UserUserIdRules()
		{
			this.RuleFor(x => x.UserUserId).MustAsync(this.BeValidUserByUserUserId).When(x => !x?.UserUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidLocationByLocationId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.TweetRepository.LocationByLocationId(id);

			return record != null;
		}

		protected async Task<bool> BeValidUserByUserUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.TweetRepository.UserByUserUserId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>f8986e542af8b5ec761c205c32c5d536</Hash>
</Codenesium>*/