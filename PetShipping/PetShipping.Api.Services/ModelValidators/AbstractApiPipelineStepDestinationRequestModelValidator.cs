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
        public abstract class AbstractApiPipelineStepDestinationRequestModelValidator : AbstractValidator<ApiPipelineStepDestinationRequestModel>
        {
                private int existingRecordId;

                private IPipelineStepDestinationRepository pipelineStepDestinationRepository;

                public AbstractApiPipelineStepDestinationRequestModelValidator(IPipelineStepDestinationRepository pipelineStepDestinationRepository)
                {
                        this.pipelineStepDestinationRepository = pipelineStepDestinationRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiPipelineStepDestinationRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DestinationIdRules()
                {
                        this.RuleFor(x => x.DestinationId).MustAsync(this.BeValidDestination).When(x => x?.DestinationId != null).WithMessage("Invalid reference");
                }

                public virtual void PipelineStepIdRules()
                {
                        this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStep).When(x => x?.PipelineStepId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidDestination(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.pipelineStepDestinationRepository.GetDestination(id);

                        return record != null;
                }

                private async Task<bool> BeValidPipelineStep(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.pipelineStepDestinationRepository.GetPipelineStep(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>998694d150440e03072a3ae3ab28504e</Hash>
</Codenesium>*/