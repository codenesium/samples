using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractApiStateRequestModelValidator : AbstractValidator<ApiStateRequestModel>
        {
                private int existingRecordId;

                private IStateRepository stateRepository;

                public AbstractApiStateRequestModelValidator(IStateRepository stateRepository)
                {
                        this.stateRepository = stateRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiStateRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 2);
                }
        }
}

/*<Codenesium>
    <Hash>07b1a288661d8f13695a1afdff10e606</Hash>
</Codenesium>*/