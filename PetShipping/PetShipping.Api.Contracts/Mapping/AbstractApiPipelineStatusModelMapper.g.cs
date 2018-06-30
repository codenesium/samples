using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiPipelineStatusModelMapper
        {
                public virtual ApiPipelineStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStatusRequestModel request)
                {
                        var response = new ApiPipelineStatusResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiPipelineStatusRequestModel MapResponseToRequest(
                        ApiPipelineStatusResponseModel response)
                {
                        var request = new ApiPipelineStatusRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>a12108214e40c5e8b226b6199d753d2e</Hash>
</Codenesium>*/