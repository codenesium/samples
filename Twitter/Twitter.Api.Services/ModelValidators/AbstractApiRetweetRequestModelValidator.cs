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
	public abstract class AbstractApiRetweetRequestModelValidator : AbstractValidator<ApiRetweetRequestModel>
	{
		private int existingRecordId;

		private IRetweetRepository retweetRepository;

		public AbstractApiRetweetRequestModelValidator(IRetweetRepository retweetRepository)
		{
			this.retweetRepository = retweetRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiRetweetRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DateRules()
		{
		}

		public virtual void RetwitterUserIdRules()
		{
			this.RuleFor(x => x.RetwitterUserId).MustAsync(this.BeValidUser).When(x => x?.RetwitterUserId != null).WithMessage("Invalid reference");
		}

		public virtual void TimeRules()
		{
		}

		public virtual void TweetTweetIdRules()
		{
			this.RuleFor(x => x.TweetTweetId).MustAsync(this.BeValidTweet).When(x => x?.TweetTweetId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidUser(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.retweetRepository.GetUser(id.GetValueOrDefault());

			return record != null;
		}

		private async Task<bool> BeValidTweet(int id,  CancellationToken cancellationToken)
		{
			var record = await this.retweetRepository.GetTweet(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>307a09e63e576a904b7b59ee7b2a3d3d</Hash>
</Codenesium>*/