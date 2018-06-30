using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiPipelineStepStepRequirementModelMapper
        {
                public virtual ApiPipelineStepStepRequirementResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStepStepRequirementRequestModel request)
                {
                        var response = new ApiPipelineStepStepRequirementResponseModel();
                        response.SetProperties(id,
                                               request.Details,
                                               request.PipelineStepId,
                                               request.RequirementMet);
                        return response;
                }

                public virtual ApiPipelineStepStepRequirementRequestModel MapResponseToRequest(
                        ApiPipelineStepStepRequirementResponseModel response)
                {
                        var request = new ApiPipelineStepStepRequirementRequestModel();
                        request.SetProperties(
                                response.Details,
                                response.PipelineStepId,
                                response.RequirementMet);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>ffc28c82d73bcccf9a1eb388f8745fdf</Hash>
</Codenesium>*/