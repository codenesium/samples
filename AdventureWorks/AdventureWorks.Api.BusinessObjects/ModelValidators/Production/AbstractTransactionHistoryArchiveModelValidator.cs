using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractTransactionHistoryArchiveModelValidator: AbstractValidator<TransactionHistoryArchiveModel>
	{
		public new ValidationResult Validate(TransactionHistoryArchiveModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(TransactionHistoryArchiveModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).NotNull();
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

		public virtual void QuantityRules()
		{
			this.RuleFor(x => x.Quantity).NotNull();
		}

		public virtual void ActualCostRules()
		{
			this.RuleFor(x => x.ActualCost).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>6809028640b97758079c804492a0ec41</Hash>
</Codenesium>*/