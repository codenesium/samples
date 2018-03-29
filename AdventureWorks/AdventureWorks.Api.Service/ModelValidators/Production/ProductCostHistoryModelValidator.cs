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

		public void PatchMode()
		{
			this.StartDateRules();
			this.EndDateRules();
			this.StandardCostRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>3df24f3e250a3c75290057495fca5bea</Hash>
</Codenesium>*/