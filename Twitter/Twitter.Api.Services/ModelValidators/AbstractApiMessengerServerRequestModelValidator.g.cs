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

		private IMessengerRepository messengerRepository;

		public AbstractApiMessengerServerRequestModelValidator(IMessengerRepository messengerRepository)
		{
			this.messengerRepository = messengerRepository;
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

		private async Task<bool> BeValidMessageByMessageId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.messengerRepository.MessageByMessageId(id.GetValueOrDefault());

			return record != null;
		}

		private async Task<bool> BeValidUserByToUserId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.messengerRepository.UserByToUserId(id);

			return record != null;
		}

		private async Task<bool> BeValidUserByUserId(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.messengerRepository.UserByUserId(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>79d3e9ae528f8d443830e7a833eab5b6</Hash>
</Codenesium>*/