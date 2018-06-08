using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services

{
        public abstract class AbstractApiBreedRequestModelValidator: AbstractValidator<ApiBreedRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiBreedRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiBreedRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ISpeciesRepository SpeciesRepository { get; set; }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }

                public virtual void SpeciesIdRules()
                {
                        this.RuleFor(x => x.SpeciesId).NotNull();
                        this.RuleFor(x => x.SpeciesId).MustAsync(this.BeValidSpecies).When(x => x ?.SpeciesId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidSpecies(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.SpeciesRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>8cde82d044b79f4f33bfaa11c0e93e97</Hash>
</Codenesium>*/