using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ApiTransactionHistoryArchiveRequestModelValidator: AbstractApiTransactionHistoryArchiveRequestModelValidator, IApiTransactionHistoryArchiveRequestModelValidator
        {
                public ApiTransactionHistoryArchiveRequestModelValidator()
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>94735f41b3241f7c52bebf1fce9f6bcf</Hash>
</Codenesium>*/