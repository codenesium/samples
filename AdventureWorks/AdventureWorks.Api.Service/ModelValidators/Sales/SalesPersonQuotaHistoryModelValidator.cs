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

		public void PatchMode()
		{
			this.QuotaDateRules();
			this.SalesQuotaRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>6e4a70a9b72b633507953bfc745c803d</Hash>
</Codenesium>*/