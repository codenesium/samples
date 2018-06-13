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
        public abstract class AbstractApiPetRequestModelValidator: AbstractValidator<ApiPetRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiPetRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiPetRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IBreedRepository BreedRepository { get; set; }

                public IClientRepository ClientRepository { get; set; }

                public virtual void BreedIdRules()
                {
                        this.RuleFor(x => x.BreedId).MustAsync(this.BeValidBreed).When(x => x ?.BreedId != null).WithMessage("Invalid reference");
                }

                public virtual void ClientIdRules()
                {
                        this.RuleFor(x => x.ClientId).MustAsync(this.BeValidClient).When(x => x ?.ClientId != null).WithMessage("Invalid reference");
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
                        var record = await this.BreedRepository.Get(id);

                        return record != null;
                }

                private async Task<bool> BeValidClient(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.ClientRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>945a4d2dbc1e4534ef5e0f6b7cf1c19b</Hash>
</Codenesium>*/