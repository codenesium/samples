using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractApiStateRequestModelValidator: AbstractValidator<ApiStateRequestModel>
        {
                private int existingRecordId;

                IStateRepository stateRepository;

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
    <Hash>b155d299d2db067b8f76d3798b6a47a3</Hash>
</Codenesium>*/