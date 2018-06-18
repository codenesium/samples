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
        public abstract class AbstractApiWorkOrderRequestModelValidator: AbstractValidator<ApiWorkOrderRequestModel>
        {
                private int existingRecordId;

                IWorkOrderRepository workOrderRepository;

                public AbstractApiWorkOrderRequestModelValidator(IWorkOrderRepository workOrderRepository)
                {
                        this.workOrderRepository = workOrderRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiWorkOrderRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DueDateRules()
                {
                }

                public virtual void EndDateRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void OrderQtyRules()
                {
                }

                public virtual void ProductIDRules()
                {
                }

                public virtual void ScrappedQtyRules()
                {
                }

                public virtual void ScrapReasonIDRules()
                {
                }

                public virtual void StartDateRules()
                {
                }

                public virtual void StockedQtyRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>be71e71884bb042d91d0827ec8cc9d71</Hash>
</Codenesium>*/