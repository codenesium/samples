using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractSalesOrderDetailModelValidator: AbstractValidator<SalesOrderDetailModel>
	{
		public new ValidationResult Validate(SalesOrderDetailModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(SalesOrderDetailModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void SalesOrderDetailIDRules()
		{
			RuleFor(x => x.SalesOrderDetailID).NotNull();
		}

		public virtual void CarrierTrackingNumberRules()
		{
			RuleFor(x => x.CarrierTrackingNumber).Length(0,25);
		}

		public virtual void OrderQtyRules()
		{
			RuleFor(x => x.OrderQty).NotNull();
		}

		public virtual void ProductIDRules()
		{
			RuleFor(x => x.ProductID).NotNull();
		}

		public virtual void SpecialOfferIDRules()
		{
			RuleFor(x => x.SpecialOfferID).NotNull();
		}

		public virtual void UnitPriceRules()
		{
			RuleFor(x => x.UnitPrice).NotNull();
		}

		public virtual void UnitPriceDiscountRules()
		{
			RuleFor(x => x.UnitPriceDiscount).NotNull();
		}

		public virtual void LineTotalRules()
		{
			RuleFor(x => x.LineTotal).NotNull();
		}

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>fac3b43cc52dec3663a359767a639e29</Hash>
</Codenesium>*/