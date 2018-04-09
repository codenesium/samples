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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>4bbfcadd61ce3d423b156623ca1c3a85</Hash>
</Codenesium>*/