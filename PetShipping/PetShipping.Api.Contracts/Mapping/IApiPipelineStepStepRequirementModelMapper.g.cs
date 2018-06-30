using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiPipelineStepStepRequirementModelMapper
        {
                ApiPipelineStepStepRequirementResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStepStepRequirementRequestModel request);

                ApiPipelineStepStepRequirementRequestModel MapResponseToRequest(
                        ApiPipelineStepStepRequirementResponseModel response);
        }
}

/*<Codenesium>
    <Hash>35183c64db9d1a87d0439784a68abcba</Hash>
</Codenesium>*/