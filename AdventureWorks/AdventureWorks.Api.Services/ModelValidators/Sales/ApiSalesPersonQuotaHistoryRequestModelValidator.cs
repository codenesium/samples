using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiSalesPersonQuotaHistoryRequestModelValidator: AbstractApiSalesPersonQuotaHistoryRequestModelValidator, IApiSalesPersonQuotaHistoryRequestModelValidator
        {
                public ApiSalesPersonQuotaHistoryRequestModelValidator(ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository)
                        : base(salesPersonQuotaHistoryRepository)
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
    <Hash>8c5d30f9e7fe47a811483dd2565a5f02</Hash>
</Codenesium>*/