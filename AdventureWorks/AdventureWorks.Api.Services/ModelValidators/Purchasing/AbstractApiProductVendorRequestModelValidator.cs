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
        public abstract class AbstractApiProductVendorRequestModelValidator: AbstractValidator<ApiProductVendorRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiProductVendorRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiProductVendorRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AverageLeadTimeRules()
                {
                        this.RuleFor(x => x.AverageLeadTime).NotNull();
                }

                public virtual void BusinessEntityIDRules()
                {
                        this.RuleFor(x => x.BusinessEntityID).NotNull();
                }

                public virtual void LastReceiptCostRules()
                {
                }

                public virtual void LastReceiptDateRules()
                {
                }

                public virtual void MaxOrderQtyRules()
                {
                        this.RuleFor(x => x.MaxOrderQty).NotNull();
                }

                public virtual void MinOrderQtyRules()
                {
                        this.RuleFor(x => x.MinOrderQty).NotNull();
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void OnOrderQtyRules()
                {
                }

                public virtual void StandardPriceRules()
                {
                        this.RuleFor(x => x.StandardPrice).NotNull();
                }

                public virtual void UnitMeasureCodeRules()
                {
                        this.RuleFor(x => x.UnitMeasureCode).NotNull();
                        this.RuleFor(x => x.UnitMeasureCode).Length(0, 3);
                }
        }
}

/*<Codenesium>
    <Hash>9bf23bd938690ecf789103ed3b37a180</Hash>
</Codenesium>*/