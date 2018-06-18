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

                ISalesTaxRateRepository salesTaxRateRepository;

                public AbstractApiSalesTaxRateRequestModelValidator(ISalesTaxRateRepository salesTaxRateRepository)
                {
                        this.salesTaxRateRepository = salesTaxRateRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiSalesTaxRateRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByStateProvinceIDTaxType).When(x => x ?.StateProvinceID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTaxRateRequestModel.StateProvinceID));
                }

                public virtual void TaxRateRules()
                {
                }

                public virtual void TaxTypeRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByStateProvinceIDTaxType).When(x => x ?.TaxType != null).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTaxRateRequestModel.TaxType));
                }

                private async Task<bool> BeUniqueByStateProvinceIDTaxType(ApiSalesTaxRateRequestModel model,  CancellationToken cancellationToken)
                {
                        SalesTaxRate record = await this.salesTaxRateRepository.ByStateProvinceIDTaxType(model.StateProvinceID, model.TaxType);

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
    <Hash>db45180afc49ec1a292c3fc8d0c877b7</Hash>
</Codenesium>*/