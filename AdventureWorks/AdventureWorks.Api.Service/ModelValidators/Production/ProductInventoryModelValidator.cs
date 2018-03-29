using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ProductInventoryModelValidator: AbstractProductInventoryModelValidator,IProductInventoryModelValidator
	{
		public ProductInventoryModelValidator()
		{   }

		public void CreateMode()
		{
			this.LocationIDRules();
			this.ShelfRules();
			this.BinRules();
			this.QuantityRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.LocationIDRules();
			this.ShelfRules();
			this.BinRules();
			this.QuantityRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.LocationIDRules();
			this.ShelfRules();
			this.BinRules();
			this.QuantityRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>9c0b08a60af042989e528e7db3379336</Hash>
</Codenesium>*/