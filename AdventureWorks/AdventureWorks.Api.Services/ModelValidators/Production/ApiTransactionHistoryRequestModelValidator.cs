using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiTransactionHistoryRequestModelValidator : AbstractApiTransactionHistoryRequestModelValidator, IApiTransactionHistoryRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>e5ea0382f8723d4a74ae8270316f901f</Hash>
</Codenesium>*/