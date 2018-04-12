using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class ShoppingCartItemModelValidator: AbstractShoppingCartItemModelValidator, IShoppingCartItemModelValidator
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
    <Hash>cf1047dfe7e3244a93d50cd6b51f696a</Hash>
</Codenesium>*/