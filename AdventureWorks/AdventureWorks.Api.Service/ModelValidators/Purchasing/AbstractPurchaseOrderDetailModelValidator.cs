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

		public bool BeValidPurchaseOrderHeader(int id)
		{
			Response response = new Response();

			this.PurchaseOrderHeaderRepository.GetById(id,response);
			return response.PurchaseOrderHeaders.Count > 0;
		}

		public bool BeValidProduct(int id)
		{
			Response response = new Response();

			this.ProductRepository.GetById(id,response);
			return response.Products.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>971e77612ac5fa3a9e2a5db115520044</Hash>
</Codenesium>*/