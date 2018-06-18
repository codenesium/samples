using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiSalesTerritoryHistoryRequestModelValidator: AbstractApiSalesTerritoryHistoryRequestModelValidator, IApiSalesTerritoryHistoryRequestModelValidator
        {
                public ApiSalesTerritoryHistoryRequestModelValidator(ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository)
                        : base(salesTerritoryHistoryRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryHistoryRequestModel model)
                {
                        this.EndDateRules();
                        this.ModifiedDateRules();
                        this.RowguidRules();
                        this.StartDateRules();
                        this.TerritoryIDRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryHistoryRequestModel model)
                {
                        this.EndDateRules();
                        this.ModifiedDateRules();
                        this.RowguidRules();
                        this.StartDateRules();
                        this.TerritoryIDRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>42749a32a2b4d7e16450202de47e3f3f</Hash>
</Codenesium>*/