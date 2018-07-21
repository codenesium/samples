using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiWorkOrderRoutingRequestModelValidator : AbstractApiWorkOrderRoutingRequestModelValidator, IApiWorkOrderRoutingRequestModelValidator
        {
                public ApiWorkOrderRoutingRequestModelValidator(IWorkOrderRoutingRepository workOrderRoutingRepository)
                        : base(workOrderRoutingRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderRoutingRequestModel model)
                {
                        this.ActualCostRules();
                        this.ActualEndDateRules();
                        this.ActualResourceHrRules();
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
                        this.ActualResourceHrRules();
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>43ec182bc95274631f4aeb2fc9c11670</Hash>
</Codenesium>*/