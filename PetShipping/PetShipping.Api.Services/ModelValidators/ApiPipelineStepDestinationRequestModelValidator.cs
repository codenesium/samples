using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiPipelineStepDestinationRequestModelValidator: AbstractApiPipelineStepDestinationRequestModelValidator, IApiPipelineStepDestinationRequestModelValidator
        {
                public ApiPipelineStepDestinationRequestModelValidator(IPipelineStepDestinationRepository pipelineStepDestinationRepository)
                        : base(pipelineStepDestinationRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepDestinationRequestModel model)
                {
                        this.DestinationIdRules();
                        this.PipelineStepIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepDestinationRequestModel model)
                {
                        this.DestinationIdRules();
                        this.PipelineStepIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>f9c1d9ce52f1f175ab3694fb88ae7cd2</Hash>
</Codenesium>*/