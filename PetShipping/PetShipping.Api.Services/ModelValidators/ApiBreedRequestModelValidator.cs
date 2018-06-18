using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiBreedRequestModelValidator: AbstractApiBreedRequestModelValidator, IApiBreedRequestModelValidator
        {
                public ApiBreedRequestModelValidator(IBreedRepository breedRepository)
                        : base(breedRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiBreedRequestModel model)
                {
                        this.NameRules();
                        this.SpeciesIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedRequestModel model)
                {
                        this.NameRules();
                        this.SpeciesIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>5c8fcbfb850e1e53cd8c2a1c239784c8</Hash>
</Codenesium>*/