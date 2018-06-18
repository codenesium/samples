using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiAirlineRequestModelValidator: AbstractApiAirlineRequestModelValidator, IApiAirlineRequestModelValidator
        {
                public ApiAirlineRequestModelValidator(IAirlineRepository airlineRepository)
                        : base(airlineRepository)
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
    <Hash>3da417a24d0797e51ffad051636cca9a</Hash>
</Codenesium>*/