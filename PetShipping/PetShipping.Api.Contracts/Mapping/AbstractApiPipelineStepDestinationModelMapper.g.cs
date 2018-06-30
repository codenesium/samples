using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiPipelineStepDestinationModelMapper
        {
                public virtual ApiPipelineStepDestinationResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStepDestinationRequestModel request)
                {
                        var response = new ApiPipelineStepDestinationResponseModel();
                        response.SetProperties(id,
                                               request.DestinationId,
                                               request.PipelineStepId);
                        return response;
                }

                public virtual ApiPipelineStepDestinationRequestModel MapResponseToRequest(
                        ApiPipelineStepDestinationResponseModel response)
                {
                        var request = new ApiPipelineStepDestinationRequestModel();
                        request.SetProperties(
                                response.DestinationId,
                                response.PipelineStepId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>f94d71f5714450de449a3663d5d1b6b2</Hash>
</Codenesium>*/