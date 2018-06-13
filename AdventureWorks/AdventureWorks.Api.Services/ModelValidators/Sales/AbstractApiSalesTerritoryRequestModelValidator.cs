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
        public abstract class AbstractApiSalesTerritoryRequestModelValidator: AbstractValidator<ApiSalesTerritoryRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiSalesTerritoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiSalesTerritoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ISalesTerritoryRepository SalesTerritoryRepository { get; set; }
                public virtual void CostLastYearRules()
                {
                }

                public virtual void CostYTDRules()
                {
                }

                public virtual void CountryRegionCodeRules()
                {
                        this.RuleFor(x => x.CountryRegionCode).NotNull();
                        this.RuleFor(x => x.CountryRegionCode).Length(0, 3);
                }

                public virtual void @GroupRules()
                {
                        this.RuleFor(x => x.@Group).NotNull();
                        this.RuleFor(x => x.@Group).Length(0, 50);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTerritoryRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void RowguidRules()
                {
                }

                public virtual void SalesLastYearRules()
                {
                }

                public virtual void SalesYTDRules()
                {
                }

                private async Task<bool> BeUniqueGetName(ApiSalesTerritoryRequestModel model,  CancellationToken cancellationToken)
                {
                        SalesTerritory record = await this.SalesTerritoryRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default (int) && record.TerritoryID == this.existingRecordId))
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
    <Hash>b521f366222075e0e52ed2b9bf6936e6</Hash>
</Codenesium>*/