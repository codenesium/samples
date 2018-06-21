using FluentValidation.Results;
using System;
using System.Threading.Tasks;
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
    <Hash>07b7ab35d17f1f4e13cc0c76e53a8950</Hash>
</Codenesium>*/