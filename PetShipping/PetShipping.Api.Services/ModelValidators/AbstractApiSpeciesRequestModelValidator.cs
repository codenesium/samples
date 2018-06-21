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
    <Hash>7961356d17a615ef33484a88c556da26</Hash>
</Codenesium>*/