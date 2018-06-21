using FluentValidation.Results;
using System;
using System.Threading.Tasks;
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
    <Hash>6285189c5b47f7459444c9f55cf50950</Hash>
</Codenesium>*/