using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiPetRequestModelValidator: AbstractApiPetRequestModelValidator, IApiPetRequestModelValidator
        {
                public ApiPetRequestModelValidator(IPetRepository petRepository)
                        : base(petRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiPetRequestModel model)
                {
                        this.BreedIdRules();
                        this.ClientIdRules();
                        this.NameRules();
                        this.WeightRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetRequestModel model)
                {
                        this.BreedIdRules();
                        this.ClientIdRules();
                        this.NameRules();
                        this.WeightRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>6ac9e7f6f4e6be068eb7604444ea5604</Hash>
</Codenesium>*/