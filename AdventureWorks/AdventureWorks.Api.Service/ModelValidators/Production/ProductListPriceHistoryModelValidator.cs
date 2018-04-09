using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ProductListPriceHistoryModelValidator: AbstractProductListPriceHistoryModelValidator,IProductListPriceHistoryModelValidator
	{
		public ProductListPriceHistoryModelValidator()
		{   }

		public void CreateMode()
		{
			this.StartDateRules();
			this.EndDateRules();
			this.ListPriceRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.StartDateRules();
			this.EndDateRules();
			this.ListPriceRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>bbc759b4c7c9246ec65b69dc0067c4ef</Hash>
</Codenesium>*/