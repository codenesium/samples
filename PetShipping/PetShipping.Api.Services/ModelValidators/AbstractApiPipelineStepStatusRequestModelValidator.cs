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
        public abstract class AbstractApiPipelineStepStatusRequestModelValidator: AbstractValidator<ApiPipelineStepStatusRequestModel>
        {
                private int existingRecordId;

                IPipelineStepStatusRepository pipelineStepStatusRepository;

                public AbstractApiPipelineStepStatusRequestModelValidator(IPipelineStepStatusRepository pipelineStepStatusRepository)
                {
                        this.pipelineStepStatusRepository = pipelineStepStatusRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiPipelineStepStatusRequestModel model, int id)
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
    <Hash>11afb85bafad08689de8cc5b563bc7fc</Hash>
</Codenesium>*/