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
        public abstract class AbstractApiHandlerPipelineStepRequestModelValidator: AbstractValidator<ApiHandlerPipelineStepRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiHandlerPipelineStepRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiHandlerPipelineStepRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IHandlerRepository HandlerRepository { get; set; }

                public IPipelineStepRepository PipelineStepRepository { get; set; }

                public virtual void HandlerIdRules()
                {
                        this.RuleFor(x => x.HandlerId).MustAsync(this.BeValidHandler).When(x => x ?.HandlerId != null).WithMessage("Invalid reference");
                }

                public virtual void PipelineStepIdRules()
                {
                        this.RuleFor(x => x.PipelineStepId).MustAsync(this.BeValidPipelineStep).When(x => x ?.PipelineStepId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidHandler(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.HandlerRepository.Get(id);

                        return record != null;
                }

                private async Task<bool> BeValidPipelineStep(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.PipelineStepRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>91c9ec4cd34839ae617f259d7777ed45</Hash>
</Codenesium>*/