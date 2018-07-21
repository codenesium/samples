using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractApiPipelineStepStatusRequestModelValidator : AbstractValidator<ApiPipelineStepStatusRequestModel>
        {
                private int existingRecordId;

                private IPipelineStepStatusRepository pipelineStepStatusRepository;

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
                        this.RuleFor(x => x.Name).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>952ebd93baeb88bc57ac181f2aae471a</Hash>
</Codenesium>*/