using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiWorkOrderRoutingRequestModelValidator: AbstractApiWorkOrderRoutingRequestModelValidator, IApiWorkOrderRoutingRequestModelValidator
        {
                public ApiWorkOrderRoutingRequestModelValidator(IWorkOrderRoutingRepository workOrderRoutingRepository)
                        : base(workOrderRoutingRepository)
                {
                }

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
    <Hash>495b4a74a0f662bfc70c9092cb835f2e</Hash>
</Codenesium>*/