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
			this.RuleFor(x => x.RetweeterUserId).MustAsync(this.BeValidUser).When(x => x?.RetweeterUserId != null).WithMessage("Invalid reference");
		}

		public virtual void SourceTweetIdRules()
		{
			this.RuleFor(x => x.SourceTweetId).MustAsync(this.BeValidTweet).When(x => x?.SourceTweetId != null).WithMessage("Invalid reference");
		}

		public virtual void TimeRules()
		{
		}

		private async Task<bool> BeValidUser(int id,  CancellationToken cancellationToken)
		{
			var record = await this.quoteTweetRepository.GetUser(id);

			return record != null;
		}

		private async Task<bool> BeValidTweet(int id,  CancellationToken cancellationToken)
		{
			var record = await this.quoteTweetRepository.GetTweet(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>1ff156beaa9285516d998b74533f1bfe</Hash>
</Codenesium>*/