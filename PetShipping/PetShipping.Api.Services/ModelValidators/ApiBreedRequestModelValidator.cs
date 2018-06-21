using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public class ApiBreedRequestModelValidator : AbstractApiBreedRequestModelValidator, IApiBreedRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>171fa52bf8405be731499b7c0fe594ab</Hash>
</Codenesium>*/