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
        public abstract class AbstractApiSalesTaxRateRequestModelValidator : AbstractValidator<ApiSalesTaxRateRequestModel>
        {
                private int existingRecordId;

                private ISalesTaxRateRepository salesTaxRateRepository;

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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByStateProvinceIDTaxType).When(x => x?.StateProvinceID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTaxRateRequestModel.StateProvinceID));
                }

                public virtual void TaxRateRules()
                {
                }

                public virtual void TaxTypeRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByStateProvinceIDTaxType).When(x => x?.TaxType != null).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTaxRateRequestModel.TaxType));
                }

                private async Task<bool> BeUniqueByStateProvinceIDTaxType(ApiSalesTaxRateRequestModel model,  CancellationToken cancellationToken)
                {
                        SalesTaxRate record = await this.salesTaxRateRepository.ByStateProvinceIDTaxType(model.StateProvinceID, model.TaxType);

                        if (record == null || (this.existingRecordId != default(int) && record.SalesTaxRateID == this.existingRecordId))
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
    <Hash>b66dc69de2a697c9ebb865c17ba14185</Hash>
</Codenesium>*/