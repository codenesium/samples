using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiTransactionStatusRequestModelValidator: AbstractApiTransactionStatusRequestModelValidator, IApiTransactionStatusRequestModelValidator
        {
                public ApiTransactionStatusRequestModelValidator(ITransactionStatusRepository transactionStatusRepository)
                        : base(transactionStatusRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiTransactionStatusRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionStatusRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>57a9f1c3c018b3f41904b8ab1880bf52</Hash>
</Codenesium>*/