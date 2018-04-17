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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, WorkOrderRoutingModel model)
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>0ae5bb3f71017ec7a83b03ce328eb57a</Hash>
</Codenesium>*/