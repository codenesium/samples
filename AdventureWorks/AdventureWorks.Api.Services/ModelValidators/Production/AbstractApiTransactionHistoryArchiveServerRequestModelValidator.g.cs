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

		protected ITransactionHistoryArchiveRepository TransactionHistoryArchiveRepository { get; private set; }

		public AbstractApiTransactionHistoryArchiveServerRequestModelValidator(ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository)
		{
			this.TransactionHistoryArchiveRepository = transactionHistoryArchiveRepository;
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
    <Hash>fdb22f9f7246a3631463b743f22fae51</Hash>
</Codenesium>*/