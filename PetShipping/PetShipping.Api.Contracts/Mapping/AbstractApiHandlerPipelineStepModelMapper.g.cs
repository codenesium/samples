using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiHandlerPipelineStepModelMapper
        {
                public virtual ApiHandlerPipelineStepResponseModel MapRequestToResponse(
                        int id,
                        ApiHandlerPipelineStepRequestModel request)
                {
                        var response = new ApiHandlerPipelineStepResponseModel();
                        response.SetProperties(id,
                                               request.HandlerId,
                                               request.PipelineStepId);
                        return response;
                }

                public virtual ApiHandlerPipelineStepRequestModel MapResponseToRequest(
                        ApiHandlerPipelineStepResponseModel response)
                {
                        var request = new ApiHandlerPipelineStepRequestModel();
                        request.SetProperties(
                                response.HandlerId,
                                response.PipelineStepId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>dc8430a0add56cbd0f89601254cac6b7</Hash>
</Codenesium>*/