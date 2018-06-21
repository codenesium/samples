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
        public abstract class AbstractApiOtherTransportRequestModelValidator : AbstractValidator<ApiOtherTransportRequestModel>
        {
                private int existingRecordId;

                private IOtherTransportRepository otherTransportRepository;

                public AbstractApiOtherTransportRequestModelValidator(IOtherTransportRepository otherTransportRepository)
                {
                        this.otherTransportRepository = otherTransportRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiOtherTransportRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void HandlerIdRules()
                {
                        this.RuleFor(x => x.HandlerId).MustAsync(this.BeValidHandler).When(x => x?.HandlerId != null).WithMessage("Invalid reference");
                }

                public virtual void PipelineStepIdRules()
                {
                        this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStep).When(x => x?.PipelineStepId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidHandler(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.otherTransportRepository.GetHandler(id);

                        return record != null;
                }

                private async Task<bool> BeValidPipelineStep(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.otherTransportRepository.GetPipelineStep(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>e1e41c752c13846011efcfd0274af213</Hash>
</Codenesium>*/