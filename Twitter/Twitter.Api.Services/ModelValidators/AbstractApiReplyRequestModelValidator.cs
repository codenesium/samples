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
	public abstract class AbstractApiReplyRequestModelValidator : AbstractValidator<ApiReplyRequestModel>
	{
		private int existingRecordId;

		private IReplyRepository replyRepository;

		public AbstractApiReplyRequestModelValidator(IReplyRepository replyRepository)
		{
			this.replyRepository = replyRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiReplyRequestModel model, int id)
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
			this.RuleFor(x => x.ReplierUserId).MustAsync(this.BeValidUser).When(x => x?.ReplierUserId != null).WithMessage("Invalid reference");
		}

		public virtual void TimeRules()
		{
		}

		private async Task<bool> BeValidUser(int id,  CancellationToken cancellationToken)
		{
			var record = await this.replyRepository.GetUser(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>317c2402ebd9d3265fa9e2de4f929493</Hash>
</Codenesium>*/