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
	public abstract class AbstractApiMessengerServerRequestModelValidator : AbstractValidator<ApiMessengerServerRequestModel>
	{
		private int existingRecordId;

		protected IMessengerRepository MessengerRepository { get; private set; }

		public AbstractApiMessengerServerRequestModelValidator(IMessengerRepository messengerRepository)
		{
			this.MessengerRepository = messengerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiMessengerServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DateRules()
		{
		}

		public virtual void FromUserIdRules()
		{
		}

		public virtual void MessageIdRules()
		{
			this.RuleFor(x => x.MessageId).MustAsync(this.BeValidMessageByMessageId).When(x => !x?.MessageId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void TimeRules()
		{
		}

		public virtual void ToUserIdRules()
		{
			this.RuleFor(x => x.ToUserId).MustAsync(this.BeValidUserByToUserId).When(x => !x?.ToUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void UserIdRules()
		{
			this.RuleFor(x => x.UserId).MustAsync(this.BeValidUserByUserId).When(x => !x?.UserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidMessageByMessageId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.MessengerRepository.MessageByMessageId(id.GetValueOrDefault());

			return record != null;
		}

		protected async Task<bool> BeValidUserByToUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.MessengerRepository.UserByToUserId(id);

			return record != null;
		}

		protected async Task<bool> BeValidUserByUserId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.MessengerRepository.UserByUserId(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>2901fe98528d34f3a34e1a9471e44779</Hash>
</Codenesium>*/