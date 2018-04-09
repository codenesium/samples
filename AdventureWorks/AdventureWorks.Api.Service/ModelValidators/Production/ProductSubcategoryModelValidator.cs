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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>2de3968de42f71faa00db50ccdcef2f1</Hash>
</Codenesium>*/