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
        public abstract class AbstractApiStateProvinceRequestModelValidator: AbstractValidator<ApiStateProvinceRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiStateProvinceRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiStateProvinceRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IStateProvinceRepository StateProvinceRepository { get; set; }
                public virtual void CountryRegionCodeRules()
                {
                        this.RuleFor(x => x.CountryRegionCode).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetStateProvinceCodeCountryRegionCode).When(x => x ?.CountryRegionCode != null).WithMessage("Violates unique constraint").WithName(nameof(ApiStateProvinceRequestModel.CountryRegionCode));
                        this.RuleFor(x => x.CountryRegionCode).Length(0, 3);
                }

                public virtual void IsOnlyStateProvinceFlagRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiStateProvinceRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void RowguidRules()
                {
                }

                public virtual void StateProvinceCodeRules()
                {
                        this.RuleFor(x => x.StateProvinceCode).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetStateProvinceCodeCountryRegionCode).When(x => x ?.StateProvinceCode != null).WithMessage("Violates unique constraint").WithName(nameof(ApiStateProvinceRequestModel.StateProvinceCode));
                        this.RuleFor(x => x.StateProvinceCode).Length(0, 3);
                }

                public virtual void TerritoryIDRules()
                {
                }

                private async Task<bool> BeUniqueGetName(ApiStateProvinceRequestModel model,  CancellationToken cancellationToken)
                {
                        StateProvince record = await this.StateProvinceRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default (int) && record.StateProvinceID == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
                private async Task<bool> BeUniqueGetStateProvinceCodeCountryRegionCode(ApiStateProvinceRequestModel model,  CancellationToken cancellationToken)
                {
                        StateProvince record = await this.StateProvinceRepository.GetStateProvinceCodeCountryRegionCode(model.StateProvinceCode, model.CountryRegionCode);

                        if (record == null || (this.existingRecordId != default (int) && record.StateProvinceID == this.existingRecordId))
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
    <Hash>d56786cdc0b30b7c48fb2fab8a3fef85</Hash>
</Codenesium>*/