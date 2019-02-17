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
	public abstract class AbstractApiTransactionServerRequestModelValidator : AbstractValidator<ApiTransactionServerRequestModel>
	{
		private int existingRecordId;

		protected ITransactionRepository TransactionRepository { get; private set; }

		public AbstractApiTransactionServerRequestModelValidator(ITransactionRepository transactionRepository)
		{
			this.TransactionRepository = transactionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTransactionServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AmountRules()
		{
		}

		public virtual void GatewayConfirmationNumberRules()
		{
			this.RuleFor(x => x.GatewayConfirmationNumber).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.GatewayConfirmationNumber).Length(0, 1).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void TransactionStatusIdRules()
		{
			this.RuleFor(x => x.TransactionStatusId).MustAsync(this.BeValidTransactionStatusByTransactionStatusId).When(x => !x?.TransactionStatusId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidTransactionStatusByTransactionStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.TransactionRepository.TransactionStatusByTransactionStatusId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>600240081a55d89d5b3dc304bd47db00</Hash>
</Codenesium>*/