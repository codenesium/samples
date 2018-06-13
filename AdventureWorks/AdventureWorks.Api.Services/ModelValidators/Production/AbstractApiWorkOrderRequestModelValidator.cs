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

                public ValidationResult Validate(ApiWorkOrderRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
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
    <Hash>749d0dad535dea1a9c2a57f843a671b1</Hash>
</Codenesium>*/