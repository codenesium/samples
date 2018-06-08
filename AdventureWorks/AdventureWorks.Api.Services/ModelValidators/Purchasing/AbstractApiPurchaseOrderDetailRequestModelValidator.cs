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
                        this.RuleFor(x => x.DueDate).NotNull();
                }

                public virtual void LineTotalRules()
                {
                        this.RuleFor(x => x.LineTotal).NotNull();
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void OrderQtyRules()
                {
                        this.RuleFor(x => x.OrderQty).NotNull();
                }

                public virtual void ProductIDRules()
                {
                        this.RuleFor(x => x.ProductID).NotNull();
                }

                public virtual void PurchaseOrderDetailIDRules()
                {
                        this.RuleFor(x => x.PurchaseOrderDetailID).NotNull();
                }

                public virtual void ReceivedQtyRules()
                {
                        this.RuleFor(x => x.ReceivedQty).NotNull();
                }

                public virtual void RejectedQtyRules()
                {
                        this.RuleFor(x => x.RejectedQty).NotNull();
                }

                public virtual void StockedQtyRules()
                {
                        this.RuleFor(x => x.StockedQty).NotNull();
                }

                public virtual void UnitPriceRules()
                {
                        this.RuleFor(x => x.UnitPrice).NotNull();
                }
        }
}

/*<Codenesium>
    <Hash>b9362933fe4bfc8ea9b7d1435616a4ef</Hash>
</Codenesium>*/