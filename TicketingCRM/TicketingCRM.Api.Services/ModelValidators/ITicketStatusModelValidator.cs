using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
        public interface IApiTicketStatusRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTicketStatusRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketStatusRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>57b6e6bfe9732968c5e6fef8d4033952</Hash>
</Codenesium>*/