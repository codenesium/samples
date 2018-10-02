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
			this.RuleFor(x => x.SenderUserId).MustAsync(this.BeValidUser).When(x => x?.SenderUserId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidUser(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.messageRepository.GetUser(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>655be8b3c854cb91248bb71a9be96228</Hash>
</Codenesium>*/