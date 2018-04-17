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
			this.BusinessEntityIDRules();
			this.AverageLeadTimeRules();
			this.StandardPriceRules();
			this.LastReceiptCostRules();
			this.LastReceiptDateRules();
			this.MinOrderQtyRules();
			this.MaxOrderQtyRules();
			this.OnOrderQtyRules();
			this.UnitMeasureCodeRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductVendorModel model)
		{
			this.BusinessEntityIDRules();
			this.AverageLeadTimeRules();
			this.StandardPriceRules();
			this.LastReceiptCostRules();
			this.LastReceiptDateRules();
			this.MinOrderQtyRules();
			this.MaxOrderQtyRules();
			this.OnOrderQtyRules();
			this.UnitMeasureCodeRules();
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
    <Hash>3e92eb820c52f9193d61fc56b60e8b6b</Hash>
</Codenesium>*/