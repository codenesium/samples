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
	public class ApiMessageServerRequestModelValidator : AbstractValidator<ApiMessageServerRequestModel>, IApiMessageServerRequestModelValidator
	{
		private int existingRecordId;

		protected IMessageRepository MessageRepository { get; private set; }

		public ApiMessageServerRequestModelValidator(IMessageRepository messageRepository)
		{
			this.MessageRepository = messageRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiMessageServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiMessageServerRequestModel model)
		{
			this.ContentRules();
			this.SenderUserIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiMessageServerRequestModel model)
		{
			this.ContentRules();
			this.SenderUserIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>088b501a50fd9553fa4b01af104c2105</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/