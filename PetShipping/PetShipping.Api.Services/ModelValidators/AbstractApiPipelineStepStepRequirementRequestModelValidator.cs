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
        public abstract class AbstractApiPipelineStepStepRequirementRequestModelValidator: AbstractValidator<ApiPipelineStepStepRequirementRequestModel>
        {
                private int existingRecordId;

                IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository;

                public AbstractApiPipelineStepStepRequirementRequestModelValidator(IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository)
                {
                        this.pipelineStepStepRequirementRepository = pipelineStepStepRequirementRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiPipelineStepStepRequirementRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DetailsRules()
                {
                        this.RuleFor(x => x.Details).NotNull();
                        this.RuleFor(x => x.Details).Length(0, 2147483647);
                }

                public virtual void PipelineStepIdRules()
                {
                        this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStep).When(x => x ?.PipelineStepId != null).WithMessage("Invalid reference");
                }

                public virtual void RequirementMetRules()
                {
                }

                private async Task<bool> BeValidPipelineStep(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.pipelineStepStepRequirementRepository.GetPipelineStep(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>9bc4464776923721b527ebe87e2cb6d4</Hash>
</Codenesium>*/