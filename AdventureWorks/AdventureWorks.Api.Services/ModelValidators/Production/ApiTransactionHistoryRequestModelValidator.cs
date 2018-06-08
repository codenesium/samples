using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiTransactionHistoryRequestModelValidator: AbstractApiTransactionHistoryRequestModelValidator, IApiTransactionHistoryRequestModelValidator
        {
                public ApiTransactionHistoryRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiTransactionHistoryRequestModel model)
                {
                        this.ActualCostRules();
                        this.ModifiedDateRules();
                        this.ProductIDRules();
                        this.QuantityRules();
                        this.ReferenceOrderIDRules();
                        this.ReferenceOrderLineIDRules();
                        this.TransactionDateRules();
                        this.TransactionTypeRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionHistoryRequestModel model)
                {
                        this.ActualCostRules();
                        this.ModifiedDateRules();
                        this.ProductIDRules();
                        this.QuantityRules();
                        this.ReferenceOrderIDRules();
                        this.ReferenceOrderLineIDRules();
                        this.TransactionDateRules();
                        this.TransactionTypeRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>485505b15bf4116c2562703b9301ab43</Hash>
</Codenesium>*/