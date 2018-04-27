using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ProductInventoryModelValidator: AbstractProductInventoryModelValidator, IProductInventoryModelValidator
	{
		public ProductInventoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ProductInventoryModel model)
		{
			this.BinRules();
			this.LocationIDRules();
			this.ModifiedDateRules();
			this.QuantityRules();
			this.RowguidRules();
			this.ShelfRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductInventoryModel model)
		{
			this.BinRules();
			this.LocationIDRules();
			this.ModifiedDateRules();
			this.QuantityRules();
			this.RowguidRules();
			this.ShelfRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>bea2df038651269e3b5301a4a1a98657</Hash>
</Codenesium>*/