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
        public abstract class AbstractApiPipelineStepRequestModelValidator: AbstractValidator<ApiPipelineStepRequestModel>
        {
                private int existingRecordId;

                IPipelineStepRepository pipelineStepRepository;

                public AbstractApiPipelineStepRequestModelValidator(IPipelineStepRepository pipelineStepRepository)
                {
                        this.pipelineStepRepository = pipelineStepRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiPipelineStepRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }

                public virtual void PipelineStepStatusIdRules()
                {
                        this.RuleFor(x => x.PipelineStepStatusId).MustAsync(this.BeValidPipelineStepStatus).When(x => x ?.PipelineStepStatusId != null).WithMessage("Invalid reference");
                }

                public virtual void ShipperIdRules()
                {
                        this.RuleFor(x => x.ShipperId).MustAsync(this.BeValidEmployee).When(x => x ?.ShipperId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidPipelineStepStatus(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.pipelineStepRepository.GetPipelineStepStatus(id);

                        return record != null;
                }

                private async Task<bool> BeValidEmployee(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.pipelineStepRepository.GetEmployee(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>95e64bb9ed663d09580547f61244886b</Hash>
</Codenesium>*/