using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
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
			this.RuleFor(x => x.MessageId).MustAsync(this.BeValidMessageByMessageId).When(x => !x?.MessageId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void TimeRules()
		{
		}

		public virtual void ToUserIdRules()
		{
			this.RuleFor(x => x.ToUserId).MustAsync(this.BeValidUserByToUserId).When(x => !x?.ToUserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void UserIdRules()
		{
			this.RuleFor(x => x.UserId).MustAsync(this.BeValidUserByUserId).When(x => !x?.UserId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
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
    <Hash>c364ef5cca3c168c76c93f3c1d4c46fd</Hash>
</Codenesium>*/