using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiTransactionServerRequestModelValidator : AbstractValidator<ApiTransactionServerRequestModel>
	{
		private int existingRecordId;

		private ITransactionRepository transactionRepository;

		public AbstractApiTransactionServerRequestModelValidator(ITransactionRepository transactionRepository)
		{
			this.transactionRepository = transactionRepository;
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
			this.RuleFor(x => x.GatewayConfirmationNumber).NotNull();
			this.RuleFor(x => x.GatewayConfirmationNumber).Length(0, 1);
		}

		public virtual void TransactionStatusIdRules()
		{
			this.RuleFor(x => x.TransactionStatusId).MustAsync(this.BeValidTransactionStatuByTransactionStatusId).When(x => !x?.TransactionStatusId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidTransactionStatuByTransactionStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.transactionRepository.TransactionStatuByTransactionStatusId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>b6838df11533453c29a647e00c0d2bac</Hash>
</Codenesium>*/