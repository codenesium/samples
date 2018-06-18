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

                IStateProvinceRepository stateProvinceRepository;

                public AbstractApiStateProvinceRequestModelValidator(IStateProvinceRepository stateProvinceRepository)
                {
                        this.stateProvinceRepository = stateProvinceRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiStateProvinceRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void CountryRegionCodeRules()
                {
                        this.RuleFor(x => x.CountryRegionCode).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByStateProvinceCodeCountryRegionCode).When(x => x ?.CountryRegionCode != null).WithMessage("Violates unique constraint").WithName(nameof(ApiStateProvinceRequestModel.CountryRegionCode));
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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiStateProvinceRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void RowguidRules()
                {
                }

                public virtual void StateProvinceCodeRules()
                {
                        this.RuleFor(x => x.StateProvinceCode).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByStateProvinceCodeCountryRegionCode).When(x => x ?.StateProvinceCode != null).WithMessage("Violates unique constraint").WithName(nameof(ApiStateProvinceRequestModel.StateProvinceCode));
                        this.RuleFor(x => x.StateProvinceCode).Length(0, 3);
                }

                public virtual void TerritoryIDRules()
                {
                }

                private async Task<bool> BeUniqueByName(ApiStateProvinceRequestModel model,  CancellationToken cancellationToken)
                {
                        StateProvince record = await this.stateProvinceRepository.ByName(model.Name);

                        if (record == null || (this.existingRecordId != default (int) && record.StateProvinceID == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
                private async Task<bool> BeUniqueByStateProvinceCodeCountryRegionCode(ApiStateProvinceRequestModel model,  CancellationToken cancellationToken)
                {
                        StateProvince record = await this.stateProvinceRepository.ByStateProvinceCodeCountryRegionCode(model.StateProvinceCode, model.CountryRegionCode);

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
    <Hash>9a93a811a49909d5cd14fdee30e74f5e</Hash>
</Codenesium>*/