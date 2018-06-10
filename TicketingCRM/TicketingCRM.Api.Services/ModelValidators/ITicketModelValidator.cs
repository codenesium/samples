using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
        public interface IApiTicketRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTicketRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>37b26aca5db6429b6ba2637b86dd94d2</Hash>
</Codenesium>*/