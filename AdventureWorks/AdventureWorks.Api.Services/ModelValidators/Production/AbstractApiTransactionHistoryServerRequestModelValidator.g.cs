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
	public abstract class AbstractApiTransactionHistoryServerRequestModelValidator : AbstractValidator<ApiTransactionHistoryServerRequestModel>
	{
		private int existingRecordId;

		protected ITransactionHistoryRepository TransactionHistoryRepository { get; private set; }

		public AbstractApiTransactionHistoryServerRequestModelValidator(ITransactionHistoryRepository transactionHistoryRepository)
		{
			this.TransactionHistoryRepository = transactionHistoryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTransactionHistoryServerRequestModel model, int id)
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
			this.RuleFor(x => x.ProductID).MustAsync(this.BeValidProductByProductID).When(x => !x?.ProductID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
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

		protected async Task<bool> BeValidProductByProductID(int id,  CancellationToken cancellationToken)
		{
			var record = await this.TransactionHistoryRepository.ProductByProductID(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>b91637d5482fabfbc9b086543fc6a1cf</Hash>
</Codenesium>*/