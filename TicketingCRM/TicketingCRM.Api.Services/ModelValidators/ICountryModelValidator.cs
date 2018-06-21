using FluentValidation.Results;
using System;
using System.Threading.Tasks;
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
    <Hash>30bef33e0efb11e074c3af39cf698609</Hash>
</Codenesium>*/