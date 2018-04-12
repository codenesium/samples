using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class SalesReasonModelValidator: AbstractSalesReasonModelValidator, ISalesReasonModelValidator
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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>e33e095668a1d75be4daf6d803cdc2da</Hash>
</Codenesium>*/