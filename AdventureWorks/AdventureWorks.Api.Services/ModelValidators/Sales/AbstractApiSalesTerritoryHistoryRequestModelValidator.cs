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
        public abstract class AbstractApiSalesTerritoryHistoryRequestModelValidator : AbstractValidator<ApiSalesTerritoryHistoryRequestModel>
        {
                private int existingRecordId;

                private ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository;

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
                        this.RuleFor(x => x.TerritoryID).MustAsync(this.BeValidSalesTerritory).When(x => x?.TerritoryID != null).WithMessage("Invalid reference");
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
    <Hash>2eb30430630f040fd8fe0c062fd492f6</Hash>
</Codenesium>*/