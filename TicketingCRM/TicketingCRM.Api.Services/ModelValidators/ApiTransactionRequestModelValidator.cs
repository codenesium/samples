using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiTransactionRequestModelValidator: AbstractApiTransactionRequestModelValidator, IApiTransactionRequestModelValidator
        {
                public ApiTransactionRequestModelValidator()
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
    <Hash>1e8aa278697c0dfed3bccfa955de0b19</Hash>
</Codenesium>*/