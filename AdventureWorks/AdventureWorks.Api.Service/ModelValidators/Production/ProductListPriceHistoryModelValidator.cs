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

		public void PatchMode()
		{
			this.StartDateRules();
			this.EndDateRules();
			this.ListPriceRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>19c6697357d4ccd4bbdb65f898a25140</Hash>
</Codenesium>*/