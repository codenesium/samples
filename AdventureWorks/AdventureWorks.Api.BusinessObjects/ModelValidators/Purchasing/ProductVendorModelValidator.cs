using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ProductVendorModelValidator: AbstractProductVendorModelValidator, IProductVendorModelValidator
	{
		public ProductVendorModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ProductVendorModel model)
		{
			this.AverageLeadTimeRules();
			this.BusinessEntityIDRules();
			this.LastReceiptCostRules();
			this.LastReceiptDateRules();
			this.MaxOrderQtyRules();
			this.MinOrderQtyRules();
			this.ModifiedDateRules();
			this.OnOrderQtyRules();
			this.StandardPriceRules();
			this.UnitMeasureCodeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductVendorModel model)
		{
			this.AverageLeadTimeRules();
			this.BusinessEntityIDRules();
			this.LastReceiptCostRules();
			this.LastReceiptDateRules();
			this.MaxOrderQtyRules();
			this.MinOrderQtyRules();
			this.ModifiedDateRules();
			this.OnOrderQtyRules();
			this.StandardPriceRules();
			this.UnitMeasureCodeRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>831fca388e7735fce05868210e9e8d10</Hash>
</Codenesium>*/