using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
        public interface IApiCountryRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiCountryRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>d833a53ffa5b0d2b9483204a90566ce1</Hash>
</Codenesium>*/