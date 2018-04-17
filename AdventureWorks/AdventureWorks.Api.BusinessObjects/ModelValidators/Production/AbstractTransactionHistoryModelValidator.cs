using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

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

		public IProductRepository ProductRepository { get; set; }
		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).NotNull();
			this.RuleFor(x => x.ProductID).Must(this.BeValidProduct).When(x => x ?.ProductID != null).WithMessage("Invalid reference");
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

		private bool BeValidProduct(int id)
		{
			return this.ProductRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>293dcc36e6d690f6fc1024de52bcda93</Hash>
</Codenesium>*/