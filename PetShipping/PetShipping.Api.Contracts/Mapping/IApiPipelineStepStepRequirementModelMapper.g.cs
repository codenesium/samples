using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiPipelineStepStepRequirementModelMapper
        {
                ApiPipelineStepStepRequirementResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStepStepRequirementRequestModel request);

                ApiPipelineStepStepRequirementRequestModel MapResponseToRequest(
                        ApiPipelineStepStepRequirementResponseModel response);

                JsonPatchDocument<ApiPipelineStepStepRequirementRequestModel> CreatePatch(ApiPipelineStepStepRequirementRequestModel model);
        }
}

/*<Codenesium>
    <Hash>a76605f6dbe762d113f1c2d560a9d6f1</Hash>
</Codenesium>*/