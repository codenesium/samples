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
			this.CarrierTrackingNumberRules();
			this.LineTotalRules();
			this.ModifiedDateRules();
			this.OrderQtyRules();
			this.ProductIDRules();
			this.RowguidRules();
			this.SalesOrderDetailIDRules();
			this.SpecialOfferIDRules();
			this.UnitPriceRules();
			this.UnitPriceDiscountRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SalesOrderDetailModel model)
		{
			this.CarrierTrackingNumberRules();
			this.LineTotalRules();
			this.ModifiedDateRules();
			this.OrderQtyRules();
			this.ProductIDRules();
			this.RowguidRules();
			this.SalesOrderDetailIDRules();
			this.SpecialOfferIDRules();
			this.UnitPriceRules();
			this.UnitPriceDiscountRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>8e34c78d8d1c22d9bd0d29f9d4f8d580</Hash>
</Codenesium>*/