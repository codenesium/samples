using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiPipelineStepModelMapper
        {
                public virtual ApiPipelineStepResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStepRequestModel request)
                {
                        var response = new ApiPipelineStepResponseModel();
                        response.SetProperties(id,
                                               request.Name,
                                               request.PipelineStepStatusId,
                                               request.ShipperId);
                        return response;
                }

                public virtual ApiPipelineStepRequestModel MapResponseToRequest(
                        ApiPipelineStepResponseModel response)
                {
                        var request = new ApiPipelineStepRequestModel();
                        request.SetProperties(
                                response.Name,
                                response.PipelineStepStatusId,
                                response.ShipperId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>683cc22bc7874891c84b8d831176dfbb</Hash>
</Codenesium>*/