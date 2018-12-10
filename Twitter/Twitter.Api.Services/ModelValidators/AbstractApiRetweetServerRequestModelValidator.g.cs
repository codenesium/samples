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
	public abstract class AbstractApiRetweetServerRequestModelValidator : AbstractValidator<ApiRetweetServerRequestModel>
	{
		private int existingRecordId;

		protected IRetweetRepository RetweetRepository { get; private set; }

		public AbstractApiRetweetServerRequestModelValidator(IRetweetRepository retweetRepository)
		{
			this.RetweetRepository = retweetRepository;
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
			this.RuleFor(x => x.RetwitterUserId).MustAsync(this.BeValidUserByRetwitterUserId).When(x => !x?.RetwitterUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void TimeRules()
		{
		}

		public virtual void TweetTweetIdRules()
		{
			this.RuleFor(x => x.TweetTweetId).MustAsync(this.BeValidTweetByTweetTweetId).When(x => !x?.TweetTweetId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidUserByRetwitterUserId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.RetweetRepository.UserByRetwitterUserId(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidTweetByTweetTweetId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.RetweetRepository.TweetByTweetTweetId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>c7cd740836b3aa37e77499bc81392411</Hash>
</Codenesium>*/