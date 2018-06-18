using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiPipelineStepStepRequirementRequestModelValidator: AbstractApiPipelineStepStepRequirementRequestModelValidator, IApiPipelineStepStepRequirementRequestModelValidator
        {
                public ApiPipelineStepStepRequirementRequestModelValidator(IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository)
                        : base(pipelineStepStepRequirementRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStepRequirementRequestModel model)
                {
                        this.DetailsRules();
                        this.PipelineStepIdRules();
                        this.RequirementMetRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStepRequirementRequestModel model)
                {
                        this.DetailsRules();
                        this.PipelineStepIdRules();
                        this.RequirementMetRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>0d4c995a8d4a67796463dc9e08e071ca</Hash>
</Codenesium>*/