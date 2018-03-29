using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class SalesReasonModelValidator: AbstractSalesReasonModelValidator,ISalesReasonModelValidator
	{
		public SalesReasonModelValidator()
		{   }

		public void CreateMode()
		{
			this.NameRules();
			this.ReasonTypeRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.NameRules();
			this.ReasonTypeRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.NameRules();
			this.ReasonTypeRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>0c20fa0d71298c72df3f661b4fbe91ca</Hash>
</Codenesium>*/