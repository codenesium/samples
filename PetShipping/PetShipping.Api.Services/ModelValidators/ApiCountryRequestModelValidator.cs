using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiCountryRequestModelValidator: AbstractApiCountryRequestModelValidator, IApiCountryRequestModelValidator
        {
                public ApiCountryRequestModelValidator(ICountryRepository countryRepository)
                        : base(countryRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiCountryRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>58e0f408568b28e9f00f6919cbe60b52</Hash>
</Codenesium>*/