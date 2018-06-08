using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiDestinationRequestModelValidator: AbstractApiDestinationRequestModelValidator, IApiDestinationRequestModelValidator
        {
                public ApiDestinationRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiDestinationRequestModel model)
                {
                        this.CountryIdRules();
                        this.NameRules();
                        this.OrderRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDestinationRequestModel model)
                {
                        this.CountryIdRules();
                        this.NameRules();
                        this.OrderRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>2faec4d6c6c0b0571798794f78140d8b</Hash>
</Codenesium>*/