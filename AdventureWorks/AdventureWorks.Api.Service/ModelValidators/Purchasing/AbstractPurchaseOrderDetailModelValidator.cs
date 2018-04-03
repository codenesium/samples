using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractPurchaseOrderDetailModelValidator: AbstractValidator<PurchaseOrderDetailModel>
	{
		public new ValidationResult Validate(PurchaseOrderDetailModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(PurchaseOrderDetailModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void PurchaseOrderDetailIDRules()
		{
			RuleFor(x => x.PurchaseOrderDetailID).NotNull();
		}

		public virtual void DueDateRules()
		{
			RuleFor(x => x.DueDate).NotNull();
		}

		public virtual void OrderQtyRules()
		{
			RuleFor(x => x.OrderQty).NotNull();
		}

		public virtual void ProductIDRules()
		{
			RuleFor(x => x.ProductID).NotNull();
		}

		public virtual void UnitPriceRules()
		{
			RuleFor(x => x.UnitPrice).NotNull();
		}

		public virtual void LineTotalRules()
		{
			RuleFor(x => x.LineTotal).NotNull();
		}

		public virtual void ReceivedQtyRules()
		{
			RuleFor(x => x.ReceivedQty).NotNull();
		}

		public virtual void RejectedQtyRules()
		{
			RuleFor(x => x.RejectedQty).NotNull();
		}

		public virtual void StockedQtyRules()
		{
			RuleFor(x => x.StockedQty).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>0eb1f4bd90a2783b306c7a1bf6cf296b</Hash>
</Codenesium>*/