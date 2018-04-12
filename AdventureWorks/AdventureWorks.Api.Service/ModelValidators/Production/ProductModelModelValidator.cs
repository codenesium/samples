using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class ProductModelModelValidator: AbstractProductModelModelValidator, IProductModelModelValidator
	{
		public ProductModelModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.CatalogDescriptionRules();
			this.InstructionsRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.CatalogDescriptionRules();
			this.InstructionsRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>4aa33d70ccedb063f13535781fd57ae4</Hash>
</Codenesium>*/