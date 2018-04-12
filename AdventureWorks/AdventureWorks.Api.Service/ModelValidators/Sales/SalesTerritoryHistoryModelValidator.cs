using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class SalesTerritoryHistoryModelValidator: AbstractSalesTerritoryHistoryModelValidator, ISalesTerritoryHistoryModelValidator
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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>64ced9bb556e45518a838268d477ac54</Hash>
</Codenesium>*/