using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
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
			this.RuleFor(x => x.Content).NotNull();
			this.RuleFor(x => x.Content).Length(0, 140);
		}

		public virtual void DateRules()
		{
		}

		public virtual void LocationIdRules()
		{
			this.RuleFor(x => x.LocationId).MustAsync(this.BeValidLocationByLocationId).When(x => !x?.LocationId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void TimeRules()
		{
		}

		public virtual void UserUserIdRules()
		{
			this.RuleFor(x => x.UserUserId).MustAsync(this.BeValidUserByUserUserId).When(x => !x?.UserUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
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
    <Hash>fe14f8caf771acf7623d6de3542cbb73</Hash>
</Codenesium>*/