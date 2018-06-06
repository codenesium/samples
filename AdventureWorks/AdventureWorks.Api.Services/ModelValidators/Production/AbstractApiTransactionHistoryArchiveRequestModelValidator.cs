using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services

{
	public abstract class AbstractApiTransactionHistoryArchiveRequestModelValidator: AbstractValidator<ApiTransactionHistoryArchiveRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiTransactionHistoryArchiveRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiTransactionHistoryArchiveRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public virtual void ActualCostRules()
		{
			this.RuleFor(x => x.ActualCost).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).NotNull();
		}

		public virtual void QuantityRules()
		{
			this.RuleFor(x => x.Quantity).NotNull();
		}

		public virtual void ReferenceOrderIDRules()
		{
			this.RuleFor(x => x.ReferenceOrderID).NotNull();
		}

		public virtual void ReferenceOrderLineIDRules()
		{
			this.RuleFor(x => x.ReferenceOrderLineID).NotNull();
		}

		public virtual void TransactionDateRules()
		{
			this.RuleFor(x => x.TransactionDate).NotNull();
		}

		public virtual void TransactionTypeRules()
		{
			this.RuleFor(x => x.TransactionType).NotNull();
			this.RuleFor(x => x.TransactionType).Length(0, 1);
		}
	}
}

/*<Codenesium>
    <Hash>95af6a86cde65128f72c99cb70afd339</Hash>
</Codenesium>*/