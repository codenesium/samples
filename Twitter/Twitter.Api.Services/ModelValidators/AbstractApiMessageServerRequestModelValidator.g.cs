using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractApiMessageServerRequestModelValidator : AbstractValidator<ApiMessageServerRequestModel>
	{
		private int existingRecordId;

		private IMessageRepository messageRepository;

		public AbstractApiMessageServerRequestModelValidator(IMessageRepository messageRepository)
		{
			this.messageRepository = messageRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiMessageServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ContentRules()
		{
			this.RuleFor(x => x.Content).Length(0, 128);
		}

		public virtual void SenderUserIdRules()
		{
			this.RuleFor(x => x.SenderUserId).MustAsync(this.BeValidUserBySenderUserId).When(x => !x?.SenderUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidUserBySenderUserId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.messageRepository.UserBySenderUserId(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>f48aa3a03b2dc5df4b397a6fb75af388</Hash>
</Codenesium>*/