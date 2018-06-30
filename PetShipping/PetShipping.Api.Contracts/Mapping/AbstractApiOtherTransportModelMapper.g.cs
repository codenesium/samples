using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiOtherTransportModelMapper
        {
                public virtual ApiOtherTransportResponseModel MapRequestToResponse(
                        int id,
                        ApiOtherTransportRequestModel request)
                {
                        var response = new ApiOtherTransportResponseModel();
                        response.SetProperties(id,
                                               request.HandlerId,
                                               request.PipelineStepId);
                        return response;
                }

                public virtual ApiOtherTransportRequestModel MapResponseToRequest(
                        ApiOtherTransportResponseModel response)
                {
                        var request = new ApiOtherTransportRequestModel();
                        request.SetProperties(
                                response.HandlerId,
                                response.PipelineStepId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>15bb20a1133f3d7ac8552c649e85c937</Hash>
</Codenesium>*/