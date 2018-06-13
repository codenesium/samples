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
        public abstract class AbstractApiCurrencyRequestModelValidator: AbstractValidator<ApiCurrencyRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiCurrencyRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiCurrencyRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ICurrencyRepository CurrencyRepository { get; set; }
                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCurrencyRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                private async Task<bool> BeUniqueGetName(ApiCurrencyRequestModel model,  CancellationToken cancellationToken)
                {
                        Currency record = await this.CurrencyRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default (string) && record.CurrencyCode == this.existingRecordId))
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
    <Hash>fd28523e5e7502750780755f19719063</Hash>
</Codenesium>*/