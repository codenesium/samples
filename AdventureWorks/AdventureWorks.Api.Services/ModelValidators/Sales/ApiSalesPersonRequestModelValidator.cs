using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiSalesPersonRequestModelValidator: AbstractApiSalesPersonRequestModelValidator, IApiSalesPersonRequestModelValidator
        {
                public ApiSalesPersonRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonRequestModel model)
                {
                        this.BonusRules();
                        this.CommissionPctRules();
                        this.ModifiedDateRules();
                        this.RowguidRules();
                        this.SalesLastYearRules();
                        this.SalesQuotaRules();
                        this.SalesYTDRules();
                        this.TerritoryIDRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonRequestModel model)
                {
                        this.BonusRules();
                        this.CommissionPctRules();
                        this.ModifiedDateRules();
                        this.RowguidRules();
                        this.SalesLastYearRules();
                        this.SalesQuotaRules();
                        this.SalesYTDRules();
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
    <Hash>7730bca201b4d21dc46767a067b3389f</Hash>
</Codenesium>*/