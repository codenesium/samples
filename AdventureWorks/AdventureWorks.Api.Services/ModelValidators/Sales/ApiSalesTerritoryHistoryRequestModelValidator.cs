using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiSalesTerritoryHistoryRequestModelValidator : AbstractApiSalesTerritoryHistoryRequestModelValidator, IApiSalesTerritoryHistoryRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>00a2ca75d370b6df8ec2643c8a5237e7</Hash>
</Codenesium>*/