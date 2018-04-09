using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class WorkOrderModelValidator: AbstractWorkOrderModelValidator,IWorkOrderModelValidator
	{
		public WorkOrderModelValidator()
		{   }

		public void CreateMode()
		{
			this.ProductIDRules();
			this.OrderQtyRules();
			this.StockedQtyRules();
			this.ScrappedQtyRules();
			this.StartDateRules();
			this.EndDateRules();
			this.DueDateRules();
			this.ScrapReasonIDRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.ProductIDRules();
			this.OrderQtyRules();
			this.StockedQtyRules();
			this.ScrappedQtyRules();
			this.StartDateRules();
			this.EndDateRules();
			this.DueDateRules();
			this.ScrapReasonIDRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>64235263aa1297712a7b7bbbff6d248c</Hash>
</Codenesium>*/