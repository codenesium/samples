using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public class ApiSpeciesRequestModelValidator: AbstractApiSpeciesRequestModelValidator, IApiSpeciesRequestModelValidator
        {
                public ApiSpeciesRequestModelValidator(ISpeciesRepository speciesRepository)
                        : base(speciesRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSpeciesRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpeciesRequestModel model)
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
    <Hash>da5fac0bee3a464fb87601589d4b8c95</Hash>
</Codenesium>*/