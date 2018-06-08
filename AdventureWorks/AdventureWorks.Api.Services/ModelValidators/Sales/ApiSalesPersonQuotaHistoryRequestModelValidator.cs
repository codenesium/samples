using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiSalesPersonQuotaHistoryRequestModelValidator: AbstractApiSalesPersonQuotaHistoryRequestModelValidator, IApiSalesPersonQuotaHistoryRequestModelValidator
        {
                public ApiSalesPersonQuotaHistoryRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonQuotaHistoryRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.QuotaDateRules();
                        this.RowguidRules();
                        this.SalesQuotaRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonQuotaHistoryRequestModel model)
                {
                        this.ModifiedDateRules();
                        this.QuotaDateRules();
                        this.RowguidRules();
                        this.SalesQuotaRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>e888fb939852496bd404832f3b215ff2</Hash>
</Codenesium>*/