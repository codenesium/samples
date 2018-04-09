using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class SalesPersonQuotaHistoryModelValidator: AbstractSalesPersonQuotaHistoryModelValidator,ISalesPersonQuotaHistoryModelValidator
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
    <Hash>9d915eb38162a769e973be234e2bf3b0</Hash>
</Codenesium>*/