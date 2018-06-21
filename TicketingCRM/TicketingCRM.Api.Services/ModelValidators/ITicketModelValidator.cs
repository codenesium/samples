using FluentValidation.Results;
using System;
using System.Threading.Tasks;
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
    <Hash>ef278c5c28878be7ed41f5912e2914db</Hash>
</Codenesium>*/