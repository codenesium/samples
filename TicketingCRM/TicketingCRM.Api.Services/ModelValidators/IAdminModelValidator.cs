using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
        public interface IApiAdminRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiAdminRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>65ced04c1b24dfd7f355b309390f9766</Hash>
</Codenesium>*/