using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiSalesOrderDetailModelValidator: AbstractValidator<ApiSalesOrderDetailModel>
	{
		public new ValidationResult Validate(ApiSalesOrderDetailModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesOrderDetailModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ISpecialOfferProductRepository SpecialOfferProductRepository { get; set; }
		public ISalesOrderHeaderRepository SalesOrderHeaderRepository { get; set; }
		public virtual void CarrierTrackingNumberRules()
		{
			this.RuleFor(x => x.CarrierTrackingNumber).Length(0, 25);
		}

		public virtual void LineTotalRules()
		{
			this.RuleFor(x => x.LineTotal).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void OrderQtyRules()
		{
			this.RuleFor(x => x.OrderQty).NotNull();
		}

		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).NotNull();
			this.RuleFor(x => x.ProductID).Must(this.BeValidSpecialOfferProduct).When(x => x ?.ProductID != null).WithMessage("Invalid reference");
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void SalesOrderDetailIDRules()
		{
			this.RuleFor(x => x.SalesOrderDetailID).NotNull();
		}

		public virtual void SpecialOfferIDRules()
		{
			this.RuleFor(x => x.SpecialOfferID).NotNull();
			this.RuleFor(x => x.SpecialOfferID).Must(this.BeValidSpecialOfferProduct).When(x => x ?.SpecialOfferID != null).WithMessage("Invalid reference");
		}

		public virtual void UnitPriceRules()
		{
			this.RuleFor(x => x.UnitPrice).NotNull();
		}

		public virtual void UnitPriceDiscountRules()
		{
			this.RuleFor(x => x.UnitPriceDiscount).NotNull();
		}

		private bool BeValidSpecialOfferProduct(int id)
		{
			return this.SpecialOfferProductRepository.Get(id) != null;
		}

		private bool BeValidSalesOrderHeader(int id)
		{
			return this.SalesOrderHeaderRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>20c3ed28dc7e994879f783819e594b99</Hash>
</Codenesium>*/