using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class SalesOrderHeaderSalesReasonModelValidator: AbstractSalesOrderHeaderSalesReasonModelValidator,ISalesOrderHeaderSalesReasonModelValidator
	{
		public SalesOrderHeaderSalesReasonModelValidator()
		{   }

		public void CreateMode()
		{
			this.SalesReasonIDRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.SalesReasonIDRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.SalesReasonIDRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>c5e784486ada5b06ed868c589d480779</Hash>
</Codenesium>*/