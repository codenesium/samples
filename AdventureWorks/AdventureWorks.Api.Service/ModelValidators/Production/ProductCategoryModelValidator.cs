using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ProductCategoryModelValidator: AbstractProductCategoryModelValidator,IProductCategoryModelValidator
	{
		public ProductCategoryModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.NameRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>abc2122561a4220e829a33cd0d2d61bb</Hash>
</Codenesium>*/