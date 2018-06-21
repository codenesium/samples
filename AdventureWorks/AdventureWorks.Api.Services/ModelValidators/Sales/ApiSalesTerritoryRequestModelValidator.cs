using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiSalesTerritoryRequestModelValidator : AbstractApiSalesTerritoryRequestModelValidator, IApiSalesTerritoryRequestModelValidator
        {
                public ApiSalesTerritoryRequestModelValidator(ISalesTerritoryRepository salesTerritoryRepository)
                        : base(salesTerritoryRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryRequestModel model)
                {
                        this.CostLastYearRules();
                        this.CostYTDRules();
                        this.CountryRegionCodeRules();
                        this.@GroupRules();
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.RowguidRules();
                        this.SalesLastYearRules();
                        this.SalesYTDRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryRequestModel model)
                {
                        this.CostLastYearRules();
                        this.CostYTDRules();
                        this.CountryRegionCodeRules();
                        this.@GroupRules();
                        this.ModifiedDateRules();
                        this.NameRules();
                        this.RowguidRules();
                        this.SalesLastYearRules();
                        this.SalesYTDRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>bd62d2bba1e1432c9601bc920597855d</Hash>
</Codenesium>*/