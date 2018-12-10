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
	public abstract class AbstractApiMessageServerRequestModelValidator : AbstractValidator<ApiMessageServerRequestModel>
	{
		private int existingRecordId;

		protected IMessageRepository MessageRepository { get; private set; }

		public AbstractApiMessageServerRequestModelValidator(IMessageRepository messageRepository)
		{
			this.MessageRepository = messageRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiMessageServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ContentRules()
		{
			this.RuleFor(x => x.Content).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void SenderUserIdRules()
		{
			this.RuleFor(x => x.SenderUserId).MustAsync(this.BeValidUserBySenderUserId).When(x => !x?.SenderUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidUserBySenderUserId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.MessageRepository.UserBySenderUserId(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>62761d69b6b94f4d2633184170fe53dc</Hash>
</Codenesium>*/