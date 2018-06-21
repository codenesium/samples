using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IBOLPipelineStepStepRequirementMapper
        {
                BOPipelineStepStepRequirement MapModelToBO(
                        int id,
                        ApiPipelineStepStepRequirementRequestModel model);

                ApiPipelineStepStepRequirementResponseModel MapBOToModel(
                        BOPipelineStepStepRequirement boPipelineStepStepRequirement);

                List<ApiPipelineStepStepRequirementResponseModel> MapBOToModel(
                        List<BOPipelineStepStepRequirement> items);
        }
}

/*<Codenesium>
    <Hash>7fa7c783839253d63d6f95eca8fa9ca7</Hash>
</Codenesium>*/