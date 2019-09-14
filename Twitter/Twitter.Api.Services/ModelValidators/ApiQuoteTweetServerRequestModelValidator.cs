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
	public class ApiQuoteTweetServerRequestModelValidator : AbstractValidator<ApiQuoteTweetServerRequestModel>, IApiQuoteTweetServerRequestModelValidator
	{
		private int existingRecordId;

		protected IQuoteTweetRepository QuoteTweetRepository { get; private set; }

		public ApiQuoteTweetServerRequestModelValidator(IQuoteTweetRepository quoteTweetRepository)
		{
			this.QuoteTweetRepository = quoteTweetRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiQuoteTweetServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiQuoteTweetServerRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.RetweeterUserIdRules();
			this.SourceTweetIdRules();
			this.TimeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiQuoteTweetServerRequestModel model)
		{
			this.ContentRules();
			this.DateRules();
			this.RetweeterUserIdRules();
			this.SourceTweetIdRules();
			this.TimeRules();
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

		public virtual void RetweeterUserIdRules()
		{
			this.RuleFor(x => x.RetweeterUserId).MustAsync(this.BeValidUserByRetweeterUserId).When(x => !x?.RetweeterUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void SourceTweetIdRules()
		{
			this.RuleFor(x => x.SourceTweetId).MustAsync(this.BeValidTweetBySourceTweetId).When(x => !x?.SourceTweetId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void TimeRules()
		{
		}

		protected async Task<bool> BeValidUserByRetweeterUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.QuoteTweetRepository.UserByRetweeterUserId(id);

			return record != null;
		}

		protected async Task<bool> BeValidTweetBySourceTweetId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.QuoteTweetRepository.TweetBySourceTweetId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>1bf0533cea007fd77ada037a3dc2b96b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/