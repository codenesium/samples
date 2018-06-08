using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class ApiPipelineStepStepRequirementRequestModelValidator: AbstractApiPipelineStepStepRequirementRequestModelValidator, IApiPipelineStepStepRequirementRequestModelValidator
        {
                public ApiPipelineStepStepRequirementRequestModelValidator()
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
    <Hash>96b814eb8c2ce2602ad6010930644efa</Hash>
</Codenesium>*/