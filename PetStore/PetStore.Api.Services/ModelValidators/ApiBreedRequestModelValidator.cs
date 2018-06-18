using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
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
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedRequestModel model)
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
    <Hash>795923100d2e5f3a2f6ce77d3a85457d</Hash>
</Codenesium>*/