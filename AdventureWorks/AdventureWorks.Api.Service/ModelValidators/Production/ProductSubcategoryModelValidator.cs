using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ProductSubcategoryModelValidator: AbstractProductSubcategoryModelValidator,IProductSubcategoryModelValidator
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

		public void PatchMode()
		{
			this.ProductCategoryIDRules();
			this.NameRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>e2b25929157c8515d8764b686e24eccf</Hash>
</Codenesium>*/