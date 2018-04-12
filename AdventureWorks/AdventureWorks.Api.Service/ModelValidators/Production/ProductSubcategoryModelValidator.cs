using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class ProductSubcategoryModelValidator: AbstractProductSubcategoryModelValidator, IProductSubcategoryModelValidator
	{
		public ProductSubcategoryModelValidator()
		{   }

		public void CreateMode()
		{
			this.ProductCategoryIDRules();
			this.NameRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.ProductCategoryIDRules();
			this.NameRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>b3ecb17120fc51ae9f977a736b3acf91</Hash>
</Codenesium>*/