using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiWorkOrderRoutingModelValidator: AbstractApiWorkOrderRoutingModelValidator, IApiWorkOrderRoutingModelValidator
	{
		public ApiWorkOrderRoutingModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderRoutingModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderRoutingModel model)
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
    <Hash>7c3b9758f2baa640fab70f34bc7b279e</Hash>
</Codenesium>*/