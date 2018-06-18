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
        public abstract class AbstractApiPipelineRequestModelValidator: AbstractValidator<ApiPipelineRequestModel>
        {
                private int existingRecordId;

                IPipelineRepository pipelineRepository;

                public AbstractApiPipelineRequestModelValidator(IPipelineRepository pipelineRepository)
                {
                        this.pipelineRepository = pipelineRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiPipelineRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void PipelineStatusIdRules()
                {
                        this.RuleFor(x => x.PipelineStatusId).MustAsync(this.BeValidPipelineStatus).When(x => x ?.PipelineStatusId != null).WithMessage("Invalid reference");
                }

                public virtual void SaleIdRules()
                {
                }

                private async Task<bool> BeValidPipelineStatus(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.pipelineRepository.GetPipelineStatus(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>57998667a326942e2b3a12fe79bb9b2e</Hash>
</Codenesium>*/