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
			this.RuleFor(x => x.MessageId).MustAsync(this.BeValidMessage).When(x => x?.MessageId != null).WithMessage("Invalid reference");
		}

		public virtual void TimeRules()
		{
		}

		public virtual void ToUserIdRules()
		{
			this.RuleFor(x => x.ToUserId).MustAsync(this.BeValidUser).When(x => x?.ToUserId != null).WithMessage("Invalid reference");
		}

		public virtual void UserIdRules()
		{
			this.RuleFor(x => x.UserId).MustAsync(this.BeValidUser).When(x => x?.UserId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidMessage(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.messengerRepository.GetMessage(id.GetValueOrDefault());

			return record != null;
		}

		private async Task<bool> BeValidUser(int id,  CancellationToken cancellationToken)
		{
			var record = await this.messengerRepository.GetUser(id);

			return record != null;
		}

		private async Task<bool> BeValidUser(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.messengerRepository.GetUser(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>333c3c6866ea7290a5ff6032ce0ebd4e</Hash>
</Codenesium>*/