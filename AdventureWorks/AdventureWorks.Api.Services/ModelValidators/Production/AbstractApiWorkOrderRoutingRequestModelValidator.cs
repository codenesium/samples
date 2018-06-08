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

                public ValidationResult Validate(ApiWorkOrderRoutingRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
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
                        this.RuleFor(x => x.LocationID).NotNull();
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void OperationSequenceRules()
                {
                        this.RuleFor(x => x.OperationSequence).NotNull();
                }

                public virtual void PlannedCostRules()
                {
                        this.RuleFor(x => x.PlannedCost).NotNull();
                }

                public virtual void ProductIDRules()
                {
                        this.RuleFor(x => x.ProductID).NotNull();
                }

                public virtual void ScheduledEndDateRules()
                {
                        this.RuleFor(x => x.ScheduledEndDate).NotNull();
                }

                public virtual void ScheduledStartDateRules()
                {
                        this.RuleFor(x => x.ScheduledStartDate).NotNull();
                }
        }
}

/*<Codenesium>
    <Hash>358ad4044dedb2600dc87f0102d9ef86</Hash>
</Codenesium>*/