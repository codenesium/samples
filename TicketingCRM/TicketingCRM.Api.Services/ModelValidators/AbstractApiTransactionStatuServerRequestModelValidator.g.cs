using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiTransactionStatuServerRequestModelValidator : AbstractValidator<ApiTransactionStatuServerRequestModel>
	{
		private int existingRecordId;

		protected ITransactionStatuRepository TransactionStatuRepository { get; private set; }

		public AbstractApiTransactionStatuServerRequestModelValidator(ITransactionStatuRepository transactionStatuRepository)
		{
			this.TransactionStatuRepository = transactionStatuRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTransactionStatuServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>4eed323e570c0574f52fb0924f57d8e2</Hash>
</Codenesium>*/