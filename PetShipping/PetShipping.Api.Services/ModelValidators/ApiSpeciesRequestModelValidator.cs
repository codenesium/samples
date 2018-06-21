using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
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
    <Hash>1dd33cd150aff1970bde63cf1463263b</Hash>
</Codenesium>*/