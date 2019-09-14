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
	public class ApiRetweetServerRequestModelValidator : AbstractValidator<ApiRetweetServerRequestModel>, IApiRetweetServerRequestModelValidator
	{
		private int existingRecordId;

		protected IRetweetRepository RetweetRepository { get; private set; }

		public ApiRetweetServerRequestModelValidator(IRetweetRepository retweetRepository)
		{
			this.RetweetRepository = retweetRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiRetweetServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiRetweetServerRequestModel model)
		{
			this.DateRules();
			this.RetwitterUserIdRules();
			this.TimeRules();
			this.TweetTweetIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiRetweetServerRequestModel model)
		{
			this.DateRules();
			this.RetwitterUserIdRules();
			this.TimeRules();
			this.TweetTweetIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>bda7063f4a4ca7ffe2813fb3a982dd5e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/