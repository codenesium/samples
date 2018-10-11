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
	public abstract class AbstractApiMessageRequestModelValidator : AbstractValidator<ApiMessageRequestModel>
	{
		private int existingRecordId;

		private IMessageRepository messageRepository;

		public AbstractApiMessageRequestModelValidator(IMessageRepository messageRepository)
		{
			this.messageRepository = messageRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiMessageRequestModel model, int id)
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
			this.RuleFor(x => x.SenderUserId).MustAsync(this.BeValidUserBySenderUserId).When(x => x?.SenderUserId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidUserBySenderUserId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.messageRepository.UserBySenderUserId(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>a3e5bf88e90c16c164c99dd5e7197002</Hash>
</Codenesium>*/