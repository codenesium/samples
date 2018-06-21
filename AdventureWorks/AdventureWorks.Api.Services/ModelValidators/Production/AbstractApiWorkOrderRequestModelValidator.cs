using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiWorkOrderRequestModelValidator : AbstractValidator<ApiWorkOrderRequestModel>
        {
                private int existingRecordId;

                private IWorkOrderRepository workOrderRepository;

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
    <Hash>89b9b38871199723607ee99b7fa8dd57</Hash>
</Codenesium>*/