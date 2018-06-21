using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
        public interface IApiCustomerRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiCustomerRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>276a63f3b0ee1143b86e70e0f9c22d00</Hash>
</Codenesium>*/