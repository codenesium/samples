using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiAirlineRequestModelValidator: AbstractApiAirlineRequestModelValidator, IApiAirlineRequestModelValidator
        {
                public ApiAirlineRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiAirlineRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirlineRequestModel model)
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
    <Hash>524b1653f3f0e932fa1e24db73fbb7e7</Hash>
</Codenesium>*/