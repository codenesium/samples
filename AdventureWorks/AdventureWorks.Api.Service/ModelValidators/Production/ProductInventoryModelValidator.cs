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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>baf05e35fbbd5a5ba8d989fdf88b88bb</Hash>
</Codenesium>*/