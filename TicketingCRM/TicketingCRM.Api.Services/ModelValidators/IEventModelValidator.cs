using System;
using System.Threading.Tasks;
using FluentValidation.Results;
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
    <Hash>7d02bab418f2c50b948715181ccadad4</Hash>
</Codenesium>*/