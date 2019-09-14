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
	public class ApiTweetServerRequestModelValidator : AbstractValidator<ApiTweetServerRequestModel>, IApiTweetServerRequestModelValidator
	{
		private int existingRecordId;

		protected ITweetRepository TweetRepository { get; private set; }

		public ApiTweetServerRequestModelValidator(ITweetRepository tweetRepository)
		{
			this.TweetRepository = tweetRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTweetServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTweetServerRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.LocationIdRules();
			this.TimeRules();
			this.UserUserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTweetServerRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.LocationIdRules();
			this.TimeRules();
			this.UserUserIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>db8d7aae63e46c42119194e1aec6fb1e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/