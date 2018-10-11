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
	public abstract class AbstractApiTransactionRequestModelValidator : AbstractValidator<ApiTransactionRequestModel>
	{
		private int existingRecordId;

		private ITransactionRepository transactionRepository;

		public AbstractApiTransactionRequestModelValidator(ITransactionRepository transactionRepository)
		{
			this.transactionRepository = transactionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTransactionRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AmountRules()
		{
		}

		public virtual void GatewayConfirmationNumberRules()
		{
			this.RuleFor(x => x.GatewayConfirmationNumber).NotNull();
			this.RuleFor(x => x.GatewayConfirmationNumber).Length(0, 1);
		}

		public virtual void TransactionStatusIdRules()
		{
			this.RuleFor(x => x.TransactionStatusId).MustAsync(this.BeValidTransactionStatuByTransactionStatusId).When(x => x?.TransactionStatusId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidTransactionStatuByTransactionStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.transactionRepository.TransactionStatuByTransactionStatusId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>a89c4ae24525edf77f765826af3c4dde</Hash>
</Codenesium>*/