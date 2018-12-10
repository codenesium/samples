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
	public abstract class AbstractApiReplyServerRequestModelValidator : AbstractValidator<ApiReplyServerRequestModel>
	{
		private int existingRecordId;

		protected IReplyRepository ReplyRepository { get; private set; }

		public AbstractApiReplyServerRequestModelValidator(IReplyRepository replyRepository)
		{
			this.ReplyRepository = replyRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiReplyServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ContentRules()
		{
			this.RuleFor(x => x.Content).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Content).Length(0, 140).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void DateRules()
		{
		}

		public virtual void ReplierUserIdRules()
		{
			this.RuleFor(x => x.ReplierUserId).MustAsync(this.BeValidUserByReplierUserId).When(x => !x?.ReplierUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void TimeRules()
		{
		}

		protected async Task<bool> BeValidUserByReplierUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.ReplyRepository.UserByReplierUserId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>b22fadf2ff8ed41b8338dbb0dc28781b</Hash>
</Codenesium>*/