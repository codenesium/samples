using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiSalesOrderDetailRequestModelValidator: AbstractApiSalesOrderDetailRequestModelValidator, IApiSalesOrderDetailRequestModelValidator
	{
		public ApiSalesOrderDetailRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesOrderDetailRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesOrderDetailRequestModel model)
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
    <Hash>29a8606fa847d5654d133d16aad8f585</Hash>
</Codenesium>*/