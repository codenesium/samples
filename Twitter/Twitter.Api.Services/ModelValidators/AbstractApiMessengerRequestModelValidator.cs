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
	public abstract class AbstractApiMessengerRequestModelValidator : AbstractValidator<ApiMessengerRequestModel>
	{
		private int existingRecordId;

		private IMessengerRepository messengerRepository;

		public AbstractApiMessengerRequestModelValidator(IMessengerRepository messengerRepository)
		{
			this.messengerRepository = messengerRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiMessengerRequestModel model, int id)
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
			this.RuleFor(x => x.MessageId).MustAsync(this.BeValidMessageByMessageId).When(x => x?.MessageId != null).WithMessage("Invalid reference");
		}

		public virtual void TimeRules()
		{
		}

		public virtual void ToUserIdRules()
		{
			this.RuleFor(x => x.ToUserId).MustAsync(this.BeValidUserByToUserId).When(x => x?.ToUserId != null).WithMessage("Invalid reference");
		}

		public virtual void UserIdRules()
		{
			this.RuleFor(x => x.UserId).MustAsync(this.BeValidUserByUserId).When(x => x?.UserId != null).WithMessage("Invalid reference");
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
    <Hash>bd4d413b60fa417d244bf1e17ee64a4c</Hash>
</Codenesium>*/