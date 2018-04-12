using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class WorkOrderModelValidator: AbstractWorkOrderModelValidator, IWorkOrderModelValidator
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
    <Hash>154c8718218ff839c6316b701b4c91a4</Hash>
</Codenesium>*/