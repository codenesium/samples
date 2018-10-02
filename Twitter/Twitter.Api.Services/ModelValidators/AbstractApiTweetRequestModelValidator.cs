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
	public abstract class AbstractApiTweetRequestModelValidator : AbstractValidator<ApiTweetRequestModel>
	{
		private int existingRecordId;

		private ITweetRepository tweetRepository;

		public AbstractApiTweetRequestModelValidator(ITweetRepository tweetRepository)
		{
			this.tweetRepository = tweetRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTweetRequestModel model, int id)
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
			this.RuleFor(x => x.LocationId).MustAsync(this.BeValidLocation).When(x => x?.LocationId != null).WithMessage("Invalid reference");
		}

		public virtual void TimeRules()
		{
		}

		public virtual void UserUserIdRules()
		{
			this.RuleFor(x => x.UserUserId).MustAsync(this.BeValidUser).When(x => x?.UserUserId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidLocation(int id,  CancellationToken cancellationToken)
		{
			var record = await this.tweetRepository.GetLocation(id);

			return record != null;
		}

		private async Task<bool> BeValidUser(int id,  CancellationToken cancellationToken)
		{
			var record = await this.tweetRepository.GetUser(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>108212500fd33c74e77d0cea56818bb3</Hash>
</Codenesium>*/