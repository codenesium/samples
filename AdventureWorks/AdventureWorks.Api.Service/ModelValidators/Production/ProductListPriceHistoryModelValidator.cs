using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class ProductListPriceHistoryModelValidator: AbstractProductListPriceHistoryModelValidator, IProductListPriceHistoryModelValidator
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
    <Hash>2cfe183611dc5514d726e78406a7709d</Hash>
</Codenesium>*/