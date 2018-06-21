using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiPurchaseOrderDetailRequestModelValidator : AbstractValidator<ApiPurchaseOrderDetailRequestModel>
        {
                private int existingRecordId;

                private IPurchaseOrderDetailRepository purchaseOrderDetailRepository;

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
    <Hash>d547aa670848a1b9ddf05f8f1c0ab8f3</Hash>
</Codenesium>*/