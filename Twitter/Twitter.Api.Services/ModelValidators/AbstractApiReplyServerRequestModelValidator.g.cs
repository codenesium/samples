using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractApiReplyServerRequestModelValidator : AbstractValidator<ApiReplyServerRequestModel>
	{
		private int existingRecordId;

		private IReplyRepository replyRepository;

		public AbstractApiReplyServerRequestModelValidator(IReplyRepository replyRepository)
		{
			this.replyRepository = replyRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiReplyServerRequestModel model, int id)
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

		public virtual void ReplierUserIdRules()
		{
			this.RuleFor(x => x.ReplierUserId).MustAsync(this.BeValidUserByReplierUserId).When(x => !x?.ReplierUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void TimeRules()
		{
		}

		private async Task<bool> BeValidUserByReplierUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.replyRepository.UserByReplierUserId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>148fcd912319e30e562f68d4002f3aac</Hash>
</Codenesium>*/