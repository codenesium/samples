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
        public abstract class AbstractApiSalesTaxRateRequestModelValidator: AbstractValidator<ApiSalesTaxRateRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiSalesTaxRateRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiSalesTaxRateRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ISalesTaxRateRepository SalesTaxRateRepository { get; set; }
                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void RowguidRules()
                {
                }

                public virtual void StateProvinceIDRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetStateProvinceIDTaxType).When(x => x ?.StateProvinceID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTaxRateRequestModel.StateProvinceID));
                }

                public virtual void TaxRateRules()
                {
                }

                public virtual void TaxTypeRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetStateProvinceIDTaxType).When(x => x ?.TaxType != null).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTaxRateRequestModel.TaxType));
                }

                private async Task<bool> BeUniqueGetStateProvinceIDTaxType(ApiSalesTaxRateRequestModel model,  CancellationToken cancellationToken)
                {
                        SalesTaxRate record = await this.SalesTaxRateRepository.GetStateProvinceIDTaxType(model.StateProvinceID, model.TaxType);

                        if (record == null || (this.existingRecordId != default (int) && record.SalesTaxRateID == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>dd74a2a6e380df0b3e27a44651c0b0f4</Hash>
</Codenesium>*/