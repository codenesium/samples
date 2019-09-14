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
	public class ApiTransactionServerRequestModelValidator : AbstractValidator<ApiTransactionServerRequestModel>, IApiTransactionServerRequestModelValidator
	{
		private int existingRecordId;

		protected ITransactionRepository TransactionRepository { get; private set; }

		public ApiTransactionServerRequestModelValidator(ITransactionRepository transactionRepository)
		{
			this.TransactionRepository = transactionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTransactionServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTransactionServerRequestModel model)
		{
			this.AmountRules();
			this.GatewayConfirmationNumberRules();
			this.TransactionStatusIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionServerRequestModel model)
		{
			this.AmountRules();
			this.GatewayConfirmationNumberRules();
			this.TransactionStatusIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>002794b4b3bfbca648d3bb65da8dad51</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/