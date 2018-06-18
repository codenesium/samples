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
        public abstract class AbstractApiSalesTerritoryHistoryRequestModelValidator: AbstractValidator<ApiSalesTerritoryHistoryRequestModel>
        {
                private int existingRecordId;

                ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository;

                public AbstractApiSalesTerritoryHistoryRequestModelValidator(ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository)
                {
                        this.salesTerritoryHistoryRepository = salesTerritoryHistoryRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiSalesTerritoryHistoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void EndDateRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void RowguidRules()
                {
                }

                public virtual void StartDateRules()
                {
                }

                public virtual void TerritoryIDRules()
                {
                        this.RuleFor(x => x.TerritoryID).MustAsync(this.BeValidSalesTerritory).When(x => x ?.TerritoryID != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidSalesPerson(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.salesTerritoryHistoryRepository.GetSalesPerson(id);

                        return record != null;
                }

                private async Task<bool> BeValidSalesTerritory(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.salesTerritoryHistoryRepository.GetSalesTerritory(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>840e234ca3275df449e5c3df5beeba95</Hash>
</Codenesium>*/