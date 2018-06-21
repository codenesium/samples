using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
        public interface IApiSaleTicketsRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSaleTicketsRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleTicketsRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>a636f974ae9465531c6aaa5b9760ed03</Hash>
</Codenesium>*/