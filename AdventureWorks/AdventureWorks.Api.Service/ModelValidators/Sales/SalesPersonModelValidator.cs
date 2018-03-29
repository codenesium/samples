using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class SalesPersonModelValidator: AbstractSalesPersonModelValidator,ISalesPersonModelValidator
	{
		public SalesPersonModelValidator()
		{   }

		public void CreateMode()
		{
			this.TerritoryIDRules();
			this.SalesQuotaRules();
			this.BonusRules();
			this.CommissionPctRules();
			this.SalesYTDRules();
			this.SalesLastYearRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.TerritoryIDRules();
			this.SalesQuotaRules();
			this.BonusRules();
			this.CommissionPctRules();
			this.SalesYTDRules();
			this.SalesLastYearRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.TerritoryIDRules();
			this.SalesQuotaRules();
			this.BonusRules();
			this.CommissionPctRules();
			this.SalesYTDRules();
			this.SalesLastYearRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>3881b792afa76f69f4beb995b8e8ccc1</Hash>
</Codenesium>*/