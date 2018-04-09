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

		public IPurchaseOrderHeaderRepository PurchaseOrderHeaderRepository {get; set;}
		public IProductRepository ProductRepository {get; set;}
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
			RuleFor(x => x.ProductID).Must(BeValidProduct).When(x => x ?.ProductID != null).WithMessage("Invalid reference");
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

		private bool BeValidPurchaseOrderHeader(int id)
		{
			return this.PurchaseOrderHeaderRepository.GetByIdDirect(id) != null;
		}

		private bool BeValidProduct(int id)
		{
			return this.ProductRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>53074db3c8d60482f7c0722dd9c736a8</Hash>
</Codenesium>*/