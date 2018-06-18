using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public class ApiPetRequestModelValidator: AbstractApiPetRequestModelValidator, IApiPetRequestModelValidator
        {
                public ApiPetRequestModelValidator(IPetRepository petRepository)
                        : base(petRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiPetRequestModel model)
                {
                        this.AcquiredDateRules();
                        this.BreedIdRules();
                        this.DescriptionRules();
                        this.PenIdRules();
                        this.PriceRules();
                        this.SpeciesIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetRequestModel model)
                {
                        this.AcquiredDateRules();
                        this.BreedIdRules();
                        this.DescriptionRules();
                        this.PenIdRules();
                        this.PriceRules();
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
    <Hash>0e76827546c7de259748075539485dac</Hash>
</Codenesium>*/