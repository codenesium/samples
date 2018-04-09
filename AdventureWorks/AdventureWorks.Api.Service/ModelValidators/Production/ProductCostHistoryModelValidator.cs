using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ProductCostHistoryModelValidator: AbstractProductCostHistoryModelValidator,IProductCostHistoryModelValidator
	{
		public ProductCostHistoryModelValidator()
		{   }

		public void CreateMode()
		{
			this.StartDateRules();
			this.EndDateRules();
			this.StandardCostRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.StartDateRules();
			this.EndDateRules();
			this.StandardCostRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>f30a1b4bd80a2a410d0c6a32be22d932</Hash>
</Codenesium>*/