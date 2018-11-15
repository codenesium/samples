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

		private ITransactionHistoryRepository transactionHistoryRepository;

		public AbstractApiTransactionHistoryServerRequestModelValidator(ITransactionHistoryRepository transactionHistoryRepository)
		{
			this.transactionHistoryRepository = transactionHistoryRepository;
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
			this.RuleFor(x => x.TransactionType).NotNull();
			this.RuleFor(x => x.TransactionType).Length(0, 1);
		}
	}
}

/*<Codenesium>
    <Hash>fe386befd1f59ec17d15ea68bc467a17</Hash>
</Codenesium>*/