using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
        public class ApiPetRequestModelValidator : AbstractApiPetRequestModelValidator, IApiPetRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>2dfc91ec5678082554c0d417f1e266e0</Hash>
</Codenesium>*/