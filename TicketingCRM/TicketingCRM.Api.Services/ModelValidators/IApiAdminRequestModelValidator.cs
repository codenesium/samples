using FluentValidation.Results;
using System;
using System.Threading.Tasks;
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
    <Hash>fbf1f6a1f5047795031280a55d089212</Hash>
</Codenesium>*/