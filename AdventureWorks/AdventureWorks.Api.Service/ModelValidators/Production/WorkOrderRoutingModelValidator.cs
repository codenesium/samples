using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class WorkOrderRoutingModelValidator: AbstractWorkOrderRoutingModelValidator,IWorkOrderRoutingModelValidator
	{
		public WorkOrderRoutingModelValidator()
		{   }

		public void CreateMode()
		{
			this.ProductIDRules();
			this.OperationSequenceRules();
			this.LocationIDRules();
			this.ScheduledStartDateRules();
			this.ScheduledEndDateRules();
			this.ActualStartDateRules();
			this.ActualEndDateRules();
			this.ActualResourceHrsRules();
			this.PlannedCostRules();
			this.ActualCostRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.ProductIDRules();
			this.OperationSequenceRules();
			this.LocationIDRules();
			this.ScheduledStartDateRules();
			this.ScheduledEndDateRules();
			this.ActualStartDateRules();
			this.ActualEndDateRules();
			this.ActualResourceHrsRules();
			this.PlannedCostRules();
			this.ActualCostRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>77be6cd52a81cafe928d3f790ceb0738</Hash>
</Codenesium>*/