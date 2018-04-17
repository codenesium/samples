using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class SalesOrderDetailModelValidator: AbstractSalesOrderDetailModelValidator, ISalesOrderDetailModelValidator
	{
		public SalesOrderDetailModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(SalesOrderDetailModel model)
		{
			this.SalesOrderDetailIDRules();
			this.CarrierTrackingNumberRules();
			this.OrderQtyRules();
			this.ProductIDRules();
			this.SpecialOfferIDRules();
			this.UnitPriceRules();
			this.UnitPriceDiscountRules();
			this.LineTotalRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SalesOrderDetailModel model)
		{
			this.SalesOrderDetailIDRules();
			this.CarrierTrackingNumberRules();
			this.OrderQtyRules();
			this.ProductIDRules();
			this.SpecialOfferIDRules();
			this.UnitPriceRules();
			this.UnitPriceDiscountRules();
			this.LineTotalRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>8623605fcf84f0aa5ebcfee860800819</Hash>
</Codenesium>*/