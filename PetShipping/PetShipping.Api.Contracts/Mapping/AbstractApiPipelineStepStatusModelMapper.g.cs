using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiPipelineStepStatusModelMapper
        {
                public virtual ApiPipelineStepStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiPipelineStepStatusRequestModel request)
                {
                        var response = new ApiPipelineStepStatusResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiPipelineStepStatusRequestModel MapResponseToRequest(
                        ApiPipelineStepStatusResponseModel response)
                {
                        var request = new ApiPipelineStepStatusRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>9c333bc0d7179959ed5ab3fa2108a7a1</Hash>
</Codenesium>*/