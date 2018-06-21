using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
        public abstract class AbstractApiBreedRequestModelValidator : AbstractValidator<ApiBreedRequestModel>
        {
                private int existingRecordId;

                private IBreedRepository breedRepository;

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
    <Hash>a4cc0f319f271719a27a3f03bf7252e4</Hash>
</Codenesium>*/