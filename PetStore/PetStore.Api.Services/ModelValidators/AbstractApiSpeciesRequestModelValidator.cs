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
        public abstract class AbstractApiSpeciesRequestModelValidator: AbstractValidator<ApiSpeciesRequestModel>
        {
                private int existingRecordId;

                ISpeciesRepository speciesRepository;

                public AbstractApiSpeciesRequestModelValidator(ISpeciesRepository speciesRepository)
                {
                        this.speciesRepository = speciesRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiSpeciesRequestModel model, int id)
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
    <Hash>d069566d1f1826a5073d1f80952297ae</Hash>
</Codenesium>*/