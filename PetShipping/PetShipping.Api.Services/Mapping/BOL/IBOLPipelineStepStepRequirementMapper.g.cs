using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>e76816abda67b2049fa7194b12be20ea</Hash>
</Codenesium>*/