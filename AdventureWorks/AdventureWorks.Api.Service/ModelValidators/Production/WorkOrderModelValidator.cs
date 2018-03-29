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

		public void PatchMode()
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
	}
}

/*<Codenesium>
    <Hash>4370e04da7b042700815c477be8f785f</Hash>
</Codenesium>*/