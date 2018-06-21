using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiTransactionHistoryArchiveRequestModelValidator : AbstractApiTransactionHistoryArchiveRequestModelValidator, IApiTransactionHistoryArchiveRequestModelValidator
        {
                public ApiTransactionHistoryArchiveRequestModelValidator(ITransactionHistoryArchiveRepository transactionHistoryArchiveRepository)
                        : base(transactionHistoryArchiveRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiTransactionHistoryArchiveRequestModel model)
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

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionHistoryArchiveRequestModel model)
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
    <Hash>31fcc289506b27ebf5c124a7e8fd21ea</Hash>
</Codenesium>*/