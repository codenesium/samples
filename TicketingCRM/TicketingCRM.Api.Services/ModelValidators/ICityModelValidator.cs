using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
        public interface IApiCityRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiCityRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiCityRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>2dc7c7a04738ebb74f7b41790bd3774b</Hash>
</Codenesium>*/