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
                        this.RuleFor(x => x.CostLastYear).NotNull();
                }

                public virtual void CostYTDRules()
                {
                        this.RuleFor(x => x.CostYTD).NotNull();
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
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTerritoryRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void RowguidRules()
                {
                        this.RuleFor(x => x.Rowguid).NotNull();
                }

                public virtual void SalesLastYearRules()
                {
                        this.RuleFor(x => x.SalesLastYear).NotNull();
                }

                public virtual void SalesYTDRules()
                {
                        this.RuleFor(x => x.SalesYTD).NotNull();
                }

                private async Task<bool> BeUniqueGetName(ApiSalesTerritoryRequestModel model,  CancellationToken cancellationToken)
                {
                        SalesTerritory record = await this.SalesTerritoryRepository.GetName(model.Name);

                        if (record == null || record.TerritoryID == this.existingRecordId)
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
    <Hash>d3b2ec64162dc7bf9541fa1b3542315e</Hash>
</Codenesium>*/