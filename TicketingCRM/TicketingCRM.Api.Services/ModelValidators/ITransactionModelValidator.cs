using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
        public interface IApiTransactionRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTransactionRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>fef1fe917cf0d7e904d501ae9fb319e9</Hash>
</Codenesium>*/