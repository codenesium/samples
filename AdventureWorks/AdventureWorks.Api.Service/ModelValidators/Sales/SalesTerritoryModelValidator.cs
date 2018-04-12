using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class SalesTerritoryModelValidator: AbstractSalesTerritoryModelValidator, ISalesTerritoryModelValidator
	{
		public SalesTerritoryModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.CountryRegionCodeRules();
			this.@GroupRules();
			this.SalesYTDRules();
			this.SalesLastYearRules();
			this.CostYTDRules();
			this.CostLastYearRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.CountryRegionCodeRules();
			this.@GroupRules();
			this.SalesYTDRules();
			this.SalesLastYearRules();
			this.CostYTDRules();
			this.CostLastYearRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>8b2a14f9ec120165c47a15f9c930ccf0</Hash>
</Codenesium>*/