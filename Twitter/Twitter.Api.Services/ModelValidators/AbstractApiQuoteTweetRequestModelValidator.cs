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
	public abstract class AbstractApiQuoteTweetRequestModelValidator : AbstractValidator<ApiQuoteTweetRequestModel>
	{
		private int existingRecordId;

		private IQuoteTweetRepository quoteTweetRepository;

		public AbstractApiQuoteTweetRequestModelValidator(IQuoteTweetRepository quoteTweetRepository)
		{
			this.quoteTweetRepository = quoteTweetRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiQuoteTweetRequestModel model, int id)
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

		public virtual void RetweeterUserIdRules()
		{
			this.RuleFor(x => x.RetweeterUserId).MustAsync(this.BeValidUserByRetweeterUserId).When(x => x?.RetweeterUserId != null).WithMessage("Invalid reference");
		}

		public virtual void SourceTweetIdRules()
		{
			this.RuleFor(x => x.SourceTweetId).MustAsync(this.BeValidTweetBySourceTweetId).When(x => x?.SourceTweetId != null).WithMessage("Invalid reference");
		}

		public virtual void TimeRules()
		{
		}

		private async Task<bool> BeValidUserByRetweeterUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.quoteTweetRepository.UserByRetweeterUserId(id);

			return record != null;
		}

		private async Task<bool> BeValidTweetBySourceTweetId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.quoteTweetRepository.TweetBySourceTweetId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>76db74ac403ba1ae88a7f73102f420e4</Hash>
</Codenesium>*/