using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
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

                public virtual void BreedIdRules()
                {
                        this.RuleFor(x => x.BreedId).MustAsync(this.BeValidBreed).When(x => x?.BreedId != null).WithMessage("Invalid reference");
                }

                public virtual void ClientIdRules()
                {
                        this.RuleFor(x => x.ClientId).MustAsync(this.BeValidClient).When(x => x?.ClientId != null).WithMessage("Invalid reference");
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }

                public virtual void WeightRules()
                {
                }

                private async Task<bool> BeValidBreed(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.petRepository.GetBreed(id);

                        return record != null;
                }

                private async Task<bool> BeValidClient(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.petRepository.GetClient(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>3325d1e6ec6735dd4051553d4016fa07</Hash>
</Codenesium>*/