using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiTransactionRequestModelValidator: AbstractApiTransactionRequestModelValidator, IApiTransactionRequestModelValidator
        {
                public ApiTransactionRequestModelValidator(ITransactionRepository transactionRepository)
                        : base(transactionRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiTransactionRequestModel model)
                {
                        this.AmountRules();
                        this.GatewayConfirmationNumberRules();
                        this.TransactionStatusIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionRequestModel model)
                {
                        this.AmountRules();
                        this.GatewayConfirmationNumberRules();
                        this.TransactionStatusIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>404e3439ac2a7b0cded74f5682b7813c</Hash>
</Codenesium>*/