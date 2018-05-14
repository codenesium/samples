using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiSalesOrderDetailModelValidator: AbstractApiSalesOrderDetailModelValidator, IApiSalesOrderDetailModelValidator
	{
		public ApiSalesOrderDetailModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderDetailModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderDetailModel model)
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
    <Hash>a976613a404cbe80bbc97b15e7650070</Hash>
</Codenesium>*/