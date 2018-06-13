using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiCityRequestModelValidator: AbstractApiCityRequestModelValidator, IApiCityRequestModelValidator
        {
                public ApiCityRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiCityRequestModel model)
                {
                        this.NameRules();
                        this.ProvinceIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCityRequestModel model)
                {
                        this.NameRules();
                        this.ProvinceIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>a49f0ce637ad79e197f06bc3a1241c5f</Hash>
</Codenesium>*/