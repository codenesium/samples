using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class SalesOrderHeaderSalesReasonModelValidator: AbstractSalesOrderHeaderSalesReasonModelValidator, ISalesOrderHeaderSalesReasonModelValidator
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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>1462041de1a2f7badd27b4ccb0f97215</Hash>
</Codenesium>*/