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

                public ValidationResult Validate(ApiSalesTerritoryHistoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiSalesTerritoryHistoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ISalesPersonRepository SalesPersonRepository { get; set; }

                public ISalesTerritoryRepository SalesTerritoryRepository { get; set; }

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
                        var record = await this.SalesPersonRepository.Get(id);

                        return record != null;
                }

                private async Task<bool> BeValidSalesTerritory(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.SalesTerritoryRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>53fceb40f09225c9af47dccbfd1402ae</Hash>
</Codenesium>*/