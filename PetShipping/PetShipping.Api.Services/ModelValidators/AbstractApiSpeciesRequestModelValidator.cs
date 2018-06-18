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
    <Hash>30a59695ad56d7dc8002e37d89662c17</Hash>
</Codenesium>*/