using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiCityRequestModelValidator: AbstractApiCityRequestModelValidator, IApiCityRequestModelValidator
        {
                public ApiCityRequestModelValidator(ICityRepository cityRepository)
                        : base(cityRepository)
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
    <Hash>b559253ee411160610006d6d65b82280</Hash>
</Codenesium>*/