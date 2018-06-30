using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractApiSpeciesRequestModelValidator : AbstractValidator<ApiSpeciesRequestModel>
        {
                private int existingRecordId;

                private ISpeciesRepository speciesRepository;

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
    <Hash>1c5fa51eb93f7d3def89fa57608b0462</Hash>
</Codenesium>*/