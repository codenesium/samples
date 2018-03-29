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

		public void PatchMode()
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
	}
}

/*<Codenesium>
    <Hash>eac54c7d7a41d94f040b2b2b851ce2d8</Hash>
</Codenesium>*/