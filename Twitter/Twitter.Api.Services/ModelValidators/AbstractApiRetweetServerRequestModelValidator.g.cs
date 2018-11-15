using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractApiRetweetServerRequestModelValidator : AbstractValidator<ApiRetweetServerRequestModel>
	{
		private int existingRecordId;

		private IRetweetRepository retweetRepository;

		public AbstractApiRetweetServerRequestModelValidator(IRetweetRepository retweetRepository)
		{
			this.retweetRepository = retweetRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiRetweetServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DateRules()
		{
		}

		public virtual void RetwitterUserIdRules()
		{
			this.RuleFor(x => x.RetwitterUserId).MustAsync(this.BeValidUserByRetwitterUserId).When(x => !x?.RetwitterUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void TimeRules()
		{
		}

		public virtual void TweetTweetIdRules()
		{
			this.RuleFor(x => x.TweetTweetId).MustAsync(this.BeValidTweetByTweetTweetId).When(x => !x?.TweetTweetId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidUserByRetwitterUserId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.retweetRepository.UserByRetwitterUserId(id.GetValueOrDefault());

			return record != null;
		}

		private async Task<bool> BeValidTweetByTweetTweetId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.retweetRepository.TweetByTweetTweetId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>6d4a6e33ac5a754ed295f0b0f34d026c</Hash>
</Codenesium>*/