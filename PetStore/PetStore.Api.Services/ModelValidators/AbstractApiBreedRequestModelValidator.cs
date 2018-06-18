using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public abstract class AbstractApiBreedRequestModelValidator: AbstractValidator<ApiBreedRequestModel>
        {
                private int existingRecordId;

                IBreedRepository breedRepository;

                public AbstractApiBreedRequestModelValidator(IBreedRepository breedRepository)
                {
                        this.breedRepository = breedRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiBreedRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>27712a4087073d0a01c4f018663665a1</Hash>
</Codenesium>*/