using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class SalesTerritoryModelValidator: AbstractSalesTerritoryModelValidator,ISalesTerritoryModelValidator
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

		public void PatchMode()
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
	}
}

/*<Codenesium>
    <Hash>7b0089db4d06f77776c086cf2c417560</Hash>
</Codenesium>*/