using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiSalesOrderDetailRequestModelValidator : AbstractApiSalesOrderDetailRequestModelValidator, IApiSalesOrderDetailRequestModelValidator
	{
		public ApiSalesOrderDetailRequestModelValidator(ISalesOrderDetailRepository salesOrderDetailRepository)
			: base(salesOrderDetailRepository)
		{
		}

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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>305311586c39c373c41bfc0ec0777665</Hash>
</Codenesium>*/