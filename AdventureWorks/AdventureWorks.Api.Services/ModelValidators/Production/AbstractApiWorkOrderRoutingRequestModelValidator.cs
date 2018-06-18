using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiWorkOrderRoutingRequestModelValidator: AbstractValidator<ApiWorkOrderRoutingRequestModel>
        {
                private int existingRecordId;

                IWorkOrderRoutingRepository workOrderRoutingRepository;

                public AbstractApiWorkOrderRoutingRequestModelValidator(IWorkOrderRoutingRepository workOrderRoutingRepository)
                {
                        this.workOrderRoutingRepository = workOrderRoutingRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiWorkOrderRoutingRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ActualCostRules()
                {
                }

                public virtual void ActualEndDateRules()
                {
                }

                public virtual void ActualResourceHrsRules()
                {
                }

                public virtual void ActualStartDateRules()
                {
                }

                public virtual void LocationIDRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void OperationSequenceRules()
                {
                }

                public virtual void PlannedCostRules()
                {
                }

                public virtual void ProductIDRules()
                {
                }

                public virtual void ScheduledEndDateRules()
                {
                }

                public virtual void ScheduledStartDateRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>b65102d96259a2c0cfa27bd0c9a06c4b</Hash>
</Codenesium>*/