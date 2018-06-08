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
                        this.RuleFor(x => x.PipelineStatusId).NotNull();
                        this.RuleFor(x => x.PipelineStatusId).MustAsync(this.BeValidPipelineStatus).When(x => x ?.PipelineStatusId != null).WithMessage("Invalid reference");
                }

                public virtual void SaleIdRules()
                {
                        this.RuleFor(x => x.SaleId).NotNull();
                }

                private async Task<bool> BeValidPipelineStatus(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.PipelineStatusRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>b8178434075b97c376906ce2f8e8ebf9</Hash>
</Codenesium>*/