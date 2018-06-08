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
        public abstract class AbstractApiCountryRegionCurrencyRequestModelValidator: AbstractValidator<ApiCountryRegionCurrencyRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiCountryRegionCurrencyRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiCountryRegionCurrencyRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ICurrencyRepository CurrencyRepository { get; set; }

                public virtual void CurrencyCodeRules()
                {
                        this.RuleFor(x => x.CurrencyCode).NotNull();
                        this.RuleFor(x => x.CurrencyCode).MustAsync(this.BeValidCurrency).When(x => x ?.CurrencyCode != null).WithMessage("Invalid reference");
                        this.RuleFor(x => x.CurrencyCode).Length(0, 3);
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                private async Task<bool> BeValidCurrency(string id,  CancellationToken cancellationToken)
                {
                        var record = await this.CurrencyRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>0ccd7d5ff31bc3c63d710e56e1dfa0a4</Hash>
</Codenesium>*/