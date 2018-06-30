using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public class ApiPipelineStepDestinationRequestModelValidator : AbstractApiPipelineStepDestinationRequestModelValidator, IApiPipelineStepDestinationRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>76a04ddb54af4628042ec7add792a9dc</Hash>
</Codenesium>*/