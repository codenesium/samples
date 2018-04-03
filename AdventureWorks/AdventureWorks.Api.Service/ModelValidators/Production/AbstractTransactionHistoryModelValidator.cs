using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractTransactionHistoryModelValidator: AbstractValidator<TransactionHistoryModel>
	{
		public new ValidationResult Validate(TransactionHistoryModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(TransactionHistoryModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ProductIDRules()
		{
			RuleFor(x => x.ProductID).NotNull();
		}

		public virtual void ReferenceOrderIDRules()
		{
			RuleFor(x => x.ReferenceOrderID).NotNull();
		}

		public virtual void ReferenceOrderLineIDRules()
		{
			RuleFor(x => x.ReferenceOrderLineID).NotNull();
		}

		public virtual void TransactionDateRules()
		{
			RuleFor(x => x.TransactionDate).NotNull();
		}

		public virtual void TransactionTypeRules()
		{
			RuleFor(x => x.TransactionType).NotNull();
			RuleFor(x => x.TransactionType).Length(0,1);
		}

		public virtual void QuantityRules()
		{
			RuleFor(x => x.Quantity).NotNull();
		}

		public virtual void ActualCostRules()
		{
			RuleFor(x => x.ActualCost).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>8d3137c6daf2c8d9f40213054ed9e6ee</Hash>
</Codenesium>*/