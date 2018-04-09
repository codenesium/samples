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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>9476f6236d0a8532fad3caa577fec6e9</Hash>
</Codenesium>*/