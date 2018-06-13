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
                }

                public virtual void BusinessEntityIDRules()
                {
                }

                public virtual void LastReceiptCostRules()
                {
                }

                public virtual void LastReceiptDateRules()
                {
                }

                public virtual void MaxOrderQtyRules()
                {
                }

                public virtual void MinOrderQtyRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void OnOrderQtyRules()
                {
                }

                public virtual void StandardPriceRules()
                {
                }

                public virtual void UnitMeasureCodeRules()
                {
                        this.RuleFor(x => x.UnitMeasureCode).NotNull();
                        this.RuleFor(x => x.UnitMeasureCode).Length(0, 3);
                }
        }
}

/*<Codenesium>
    <Hash>eb3b1a6b49e4ab3f0ec1a263c39aea93</Hash>
</Codenesium>*/