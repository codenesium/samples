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

		private ITweetRepository tweetRepository;

		public AbstractApiTweetServerRequestModelValidator(ITweetRepository tweetRepository)
		{
			this.tweetRepository = tweetRepository;
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

		private async Task<bool> BeValidLocationByLocationId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.tweetRepository.LocationByLocationId(id);

			return record != null;
		}

		private async Task<bool> BeValidUserByUserUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.tweetRepository.UserByUserUserId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>3c8f2a1adc1dfe4320f04318c771ebea</Hash>
</Codenesium>*/