using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ShoppingCartItemModelValidator: AbstractShoppingCartItemModelValidator,IShoppingCartItemModelValidator
	{
		public ShoppingCartItemModelValidator()
		{   }

		public void CreateMode()
		{
			this.ShoppingCartIDRules();
			this.QuantityRules();
			this.ProductIDRules();
			this.DateCreatedRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.ShoppingCartIDRules();
			this.QuantityRules();
			this.ProductIDRules();
			this.DateCreatedRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.ShoppingCartIDRules();
			this.QuantityRules();
			this.ProductIDRules();
			this.DateCreatedRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>8439537bbfc08884984b9e9b2fc89377</Hash>
</Codenesium>*/