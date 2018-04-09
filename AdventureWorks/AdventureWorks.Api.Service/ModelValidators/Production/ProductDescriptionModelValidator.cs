using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ProductDescriptionModelValidator: AbstractProductDescriptionModelValidator,IProductDescriptionModelValidator
	{
		public ProductDescriptionModelValidator()
		{   }

		public void CreateMode()
		{
			this.DescriptionRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.DescriptionRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>27f18f5944d22d4feaffafa665842270</Hash>
</Codenesium>*/