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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>4d7eb108c90e453ce1aa477648fb376b</Hash>
</Codenesium>*/