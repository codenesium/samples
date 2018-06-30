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
        public abstract class AbstractApiPetRequestModelValidator : AbstractValidator<ApiPetRequestModel>
        {
                private int existingRecordId;

                private IPetRepository petRepository;

                public AbstractApiPetRequestModelValidator(IPetRepository petRepository)
                {
                        this.petRepository = petRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiPetRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AcquiredDateRules()
                {
                }

                public virtual void BreedIdRules()
                {
                        this.RuleFor(x => x.BreedId).MustAsync(this.BeValidBreed).When(x => x?.BreedId != null).WithMessage("Invalid reference");
                }

                public virtual void DescriptionRules()
                {
                        this.RuleFor(x => x.Description).NotNull();
                        this.RuleFor(x => x.Description).Length(0, 2147483647);
                }

                public virtual void PenIdRules()
                {
                        this.RuleFor(x => x.PenId).MustAsync(this.BeValidPen).When(x => x?.PenId != null).WithMessage("Invalid reference");
                }

                public virtual void PriceRules()
                {
                }

                public virtual void SpeciesIdRules()
                {
                        this.RuleFor(x => x.SpeciesId).MustAsync(this.BeValidSpecies).When(x => x?.SpeciesId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidBreed(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.petRepository.GetBreed(id);

                        return record != null;
                }

                private async Task<bool> BeValidPen(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.petRepository.GetPen(id);

                        return record != null;
                }

                private async Task<bool> BeValidSpecies(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.petRepository.GetSpecies(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>0a2c7327958213a5bc4fd593acdd68f7</Hash>
</Codenesium>*/