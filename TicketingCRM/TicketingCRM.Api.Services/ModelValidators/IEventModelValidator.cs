using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
        public interface IApiEventRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiEventRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>caa864e76e6ccde3a77582e2bd4e2b62</Hash>
</Codenesium>*/