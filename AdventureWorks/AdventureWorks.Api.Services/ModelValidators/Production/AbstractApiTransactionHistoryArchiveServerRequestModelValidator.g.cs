using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiTransactionHistoryArchiveServerRequestModelValidator : AbstractValidator<ApiTransactionHistoryArchiveServerRequestModel>
	{
		private int existingRecordId;

		private ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository;

		public AbstractApiTransactionHistoryArchiveServerRequestModelValidator(ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository)
		{
			this.transactionHistoryArchiveRepository = transactionHistoryArchiveRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTransactionHistoryArchiveServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ActualCostRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void ProductIDRules()
		{
		}

		public virtual void QuantityRules()
		{
		}

		public virtual void ReferenceOrderIDRules()
		{
		}

		public virtual void ReferenceOrderLineIDRules()
		{
		}

		public virtual void TransactionDateRules()
		{
		}

		public virtual void TransactionTypeRules()
		{
			this.RuleFor(x => x.TransactionType).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.TransactionType).Length(0, 1).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>ce6ccf7348c2372552d57d5d5354e3f3</Hash>
</Codenesium>*/