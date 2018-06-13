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
        public abstract class AbstractApiPurchaseOrderDetailRequestModelValidator: AbstractValidator<ApiPurchaseOrderDetailRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiPurchaseOrderDetailRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiPurchaseOrderDetailRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DueDateRules()
                {
                }

                public virtual void LineTotalRules()
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

                public virtual void PurchaseOrderDetailIDRules()
                {
                }

                public virtual void ReceivedQtyRules()
                {
                }

                public virtual void RejectedQtyRules()
                {
                }

                public virtual void StockedQtyRules()
                {
                }

                public virtual void UnitPriceRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>3e8fd9b8136994f6e933cd95dd1d8434</Hash>
</Codenesium>*/