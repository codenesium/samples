using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
        public class ApiSpeciesRequestModelValidator : AbstractApiSpeciesRequestModelValidator, IApiSpeciesRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>c38d6d4e0a5730034b54bb15cc464697</Hash>
</Codenesium>*/