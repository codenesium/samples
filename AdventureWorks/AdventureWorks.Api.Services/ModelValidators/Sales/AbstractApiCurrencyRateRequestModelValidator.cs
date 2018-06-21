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
        public abstract class AbstractApiCurrencyRateRequestModelValidator : AbstractValidator<ApiCurrencyRateRequestModel>
        {
                private int existingRecordId;

                private ICurrencyRateRepository currencyRateRepository;

                public AbstractApiCurrencyRateRequestModelValidator(ICurrencyRateRepository currencyRateRepository)
                {
                        this.currencyRateRepository = currencyRateRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiCurrencyRateRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AverageRateRules()
                {
                }

                public virtual void CurrencyRateDateRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByCurrencyRateDateFromCurrencyCodeToCurrencyCode).When(x => x?.CurrencyRateDate != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCurrencyRateRequestModel.CurrencyRateDate));
                }

                public virtual void EndOfDayRateRules()
                {
                }

                public virtual void FromCurrencyCodeRules()
                {
                        this.RuleFor(x => x.FromCurrencyCode).NotNull();
                        this.RuleFor(x => x.FromCurrencyCode).MustAsync(this.BeValidCurrency).When(x => x?.FromCurrencyCode != null).WithMessage("Invalid reference");
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByCurrencyRateDateFromCurrencyCodeToCurrencyCode).When(x => x?.FromCurrencyCode != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCurrencyRateRequestModel.FromCurrencyCode));
                        this.RuleFor(x => x.FromCurrencyCode).Length(0, 3);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void ToCurrencyCodeRules()
                {
                        this.RuleFor(x => x.ToCurrencyCode).NotNull();
                        this.RuleFor(x => x.ToCurrencyCode).MustAsync(this.BeValidCurrency).When(x => x?.ToCurrencyCode != null).WithMessage("Invalid reference");
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByCurrencyRateDateFromCurrencyCodeToCurrencyCode).When(x => x?.ToCurrencyCode != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCurrencyRateRequestModel.ToCurrencyCode));
                        this.RuleFor(x => x.ToCurrencyCode).Length(0, 3);
                }

                private async Task<bool> BeValidCurrency(string id,  CancellationToken cancellationToken)
                {
                        var record = await this.currencyRateRepository.GetCurrency(id);

                        return record != null;
                }

                private async Task<bool> BeUniqueByCurrencyRateDateFromCurrencyCodeToCurrencyCode(ApiCurrencyRateRequestModel model,  CancellationToken cancellationToken)
                {
                        CurrencyRate record = await this.currencyRateRepository.ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(model.CurrencyRateDate, model.FromCurrencyCode, model.ToCurrencyCode);

                        if (record == null || (this.existingRecordId != default(int) && record.CurrencyRateID == this.existingRecordId))
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
    <Hash>781a1c7c538c886445b34dd636e9fd6c</Hash>
</Codenesium>*/