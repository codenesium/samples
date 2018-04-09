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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>7bc1f31290f0cb395502e6b6380e2d39</Hash>
</Codenesium>*/