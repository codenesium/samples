using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class WorkOrderRoutingModelValidator: AbstractWorkOrderRoutingModelValidator, IWorkOrderRoutingModelValidator
	{
		public WorkOrderRoutingModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(WorkOrderRoutingModel model)
		{
			this.ActualCostRules();
			this.ActualEndDateRules();
			this.ActualResourceHrsRules();
			this.ActualStartDateRules();
			this.LocationIDRules();
			this.ModifiedDateRules();
			this.OperationSequenceRules();
			this.PlannedCostRules();
			this.ProductIDRules();
			this.ScheduledEndDateRules();
			this.ScheduledStartDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, WorkOrderRoutingModel model)
		{
			this.ActualCostRules();
			this.ActualEndDateRules();
			this.ActualResourceHrsRules();
			this.ActualStartDateRules();
			this.LocationIDRules();
			this.ModifiedDateRules();
			this.OperationSequenceRules();
			this.PlannedCostRules();
			this.ProductIDRules();
			this.ScheduledEndDateRules();
			this.ScheduledStartDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>6abbd80e32df4f0012403ac508f5a942</Hash>
</Codenesium>*/