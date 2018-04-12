using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class SalesPersonModelValidator: AbstractSalesPersonModelValidator, ISalesPersonModelValidator
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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>1dea9f3342ed5260750821b99912215d</Hash>
</Codenesium>*/