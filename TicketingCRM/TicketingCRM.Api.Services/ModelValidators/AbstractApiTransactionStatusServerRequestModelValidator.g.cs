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
	public abstract class AbstractApiTransactionStatusServerRequestModelValidator : AbstractValidator<ApiTransactionStatusServerRequestModel>
	{
		private int existingRecordId;

		protected ITransactionStatusRepository TransactionStatusRepository { get; private set; }

		public AbstractApiTransactionStatusServerRequestModelValidator(ITransactionStatusRepository transactionStatusRepository)
		{
			this.TransactionStatusRepository = transactionStatusRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTransactionStatusServerRequestModel model, int id)
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
    <Hash>0c3bb17435ecbc961652ddc7725422f6</Hash>
</Codenesium>*/