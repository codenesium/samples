using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

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
    <Hash>00ac9112fd2a5fb52eeffb087b7c1ef0</Hash>
</Codenesium>*/