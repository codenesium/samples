using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class SalesPersonQuotaHistoryModelValidator: AbstractSalesPersonQuotaHistoryModelValidator, ISalesPersonQuotaHistoryModelValidator
	{
		public SalesPersonQuotaHistoryModelValidator()
		{   }

		public void CreateMode()
		{
			this.QuotaDateRules();
			this.SalesQuotaRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.QuotaDateRules();
			this.SalesQuotaRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>fa9a9a0e0457bc377b3d15f9a68b8644</Hash>
</Codenesium>*/