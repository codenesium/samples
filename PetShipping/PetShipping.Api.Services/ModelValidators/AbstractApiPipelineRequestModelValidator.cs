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

                public ValidationResult Validate(ApiPipelineRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiPipelineRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IPipelineStatusRepository PipelineStatusRepository { get; set; }

                public virtual void PipelineStatusIdRules()
                {
                        this.RuleFor(x => x.PipelineStatusId).MustAsync(this.BeValidPipelineStatus).When(x => x ?.PipelineStatusId != null).WithMessage("Invalid reference");
                }

                public virtual void SaleIdRules()
                {
                }

                private async Task<bool> BeValidPipelineStatus(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.PipelineStatusRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>55417ab7cabc1a22b97b69c8b1db10d7</Hash>
</Codenesium>*/