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

                IPurchaseOrderDetailRepository purchaseOrderDetailRepository;

                public AbstractApiPurchaseOrderDetailRequestModelValidator(IPurchaseOrderDetailRepository purchaseOrderDetailRepository)
                {
                        this.purchaseOrderDetailRepository = purchaseOrderDetailRepository;
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
    <Hash>b0e8ba148f59a286540f26c70ac2e24e</Hash>
</Codenesium>*/