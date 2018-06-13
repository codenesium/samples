using System;
using System.Threading.Tasks;
using FluentValidation.Results;
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
    <Hash>855b10928b1caccf61cb804e345b46bf</Hash>
</Codenesium>*/