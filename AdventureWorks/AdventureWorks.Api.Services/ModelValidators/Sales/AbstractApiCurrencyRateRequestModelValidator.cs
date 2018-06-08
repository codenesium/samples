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
        public abstract class AbstractApiCurrencyRateRequestModelValidator: AbstractValidator<ApiCurrencyRateRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiCurrencyRateRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiCurrencyRateRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ICurrencyRepository CurrencyRepository { get; set; }

                public ICurrencyRateRepository CurrencyRateRepository { get; set; }
                public virtual void AverageRateRules()
                {
                        this.RuleFor(x => x.AverageRate).NotNull();
                }

                public virtual void CurrencyRateDateRules()
                {
                        this.RuleFor(x => x.CurrencyRateDate).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetCurrencyRateDateFromCurrencyCodeToCurrencyCode).When(x => x ?.CurrencyRateDate != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCurrencyRateRequestModel.CurrencyRateDate));
                }

                public virtual void EndOfDayRateRules()
                {
                        this.RuleFor(x => x.EndOfDayRate).NotNull();
                }

                public virtual void FromCurrencyCodeRules()
                {
                        this.RuleFor(x => x.FromCurrencyCode).NotNull();
                        this.RuleFor(x => x.FromCurrencyCode).MustAsync(this.BeValidCurrency).When(x => x ?.FromCurrencyCode != null).WithMessage("Invalid reference");
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetCurrencyRateDateFromCurrencyCodeToCurrencyCode).When(x => x ?.FromCurrencyCode != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCurrencyRateRequestModel.FromCurrencyCode));
                        this.RuleFor(x => x.FromCurrencyCode).Length(0, 3);
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void ToCurrencyCodeRules()
                {
                        this.RuleFor(x => x.ToCurrencyCode).NotNull();
                        this.RuleFor(x => x.ToCurrencyCode).MustAsync(this.BeValidCurrency).When(x => x ?.ToCurrencyCode != null).WithMessage("Invalid reference");
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetCurrencyRateDateFromCurrencyCodeToCurrencyCode).When(x => x ?.ToCurrencyCode != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCurrencyRateRequestModel.ToCurrencyCode));
                        this.RuleFor(x => x.ToCurrencyCode).Length(0, 3);
                }

                private async Task<bool> BeValidCurrency(string id,  CancellationToken cancellationToken)
                {
                        var record = await this.CurrencyRepository.Get(id);

                        return record != null;
                }

                private async Task<bool> BeUniqueGetCurrencyRateDateFromCurrencyCodeToCurrencyCode(ApiCurrencyRateRequestModel model,  CancellationToken cancellationToken)
                {
                        CurrencyRate record = await this.CurrencyRateRepository.GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(model.CurrencyRateDate, model.FromCurrencyCode, model.ToCurrencyCode);

                        if (record == null || record.CurrencyRateID == this.existingRecordId)
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
    <Hash>8246066d8ed50663fada2724002995ab</Hash>
</Codenesium>*/