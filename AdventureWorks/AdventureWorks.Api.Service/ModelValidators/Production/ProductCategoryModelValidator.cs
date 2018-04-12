using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class ProductCategoryModelValidator: AbstractProductCategoryModelValidator, IProductCategoryModelValidator
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
    <Hash>e2bbddba2a0f5c960b04163aa6a479f7</Hash>
</Codenesium>*/