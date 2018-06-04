using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiWorkOrderRoutingRequestModelValidator: AbstractApiWorkOrderRoutingRequestModelValidator, IApiWorkOrderRoutingRequestModelValidator
	{
		public ApiWorkOrderRoutingRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderRoutingRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderRoutingRequestModel model)
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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>4e07382b09181d84a3ac3409576054b6</Hash>
</Codenesium>*/