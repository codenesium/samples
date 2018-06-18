using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiTransactionHistoryRequestModelValidator: AbstractApiTransactionHistoryRequestModelValidator, IApiTransactionHistoryRequestModelValidator
        {
                public ApiTransactionHistoryRequestModelValidator(ITransactionHistoryRepository transactionHistoryRepository)
                        : base(transactionHistoryRepository)
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
    <Hash>12a603099d81c11003183c9123663ea2</Hash>
</Codenesium>*/