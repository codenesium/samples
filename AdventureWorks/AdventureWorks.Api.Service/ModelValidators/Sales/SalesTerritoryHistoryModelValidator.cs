using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class SalesTerritoryHistoryModelValidator: AbstractSalesTerritoryHistoryModelValidator,ISalesTerritoryHistoryModelValidator
	{
		public SalesTerritoryHistoryModelValidator()
		{   }

		public void CreateMode()
		{
			this.TerritoryIDRules();
			this.StartDateRules();
			this.EndDateRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.TerritoryIDRules();
			this.StartDateRules();
			this.EndDateRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.TerritoryIDRules();
			this.StartDateRules();
			this.EndDateRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>52ea25231008babc427db413b3e397f6</Hash>
</Codenesium>*/