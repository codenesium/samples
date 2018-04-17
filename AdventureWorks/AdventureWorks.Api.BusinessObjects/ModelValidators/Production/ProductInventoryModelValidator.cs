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
			this.LocationIDRules();
			this.ShelfRules();
			this.BinRules();
			this.QuantityRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ProductInventoryModel model)
		{
			this.LocationIDRules();
			this.ShelfRules();
			this.BinRules();
			this.QuantityRules();
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
    <Hash>22323b59eac92b543a57aab2a463417e</Hash>
</Codenesium>*/