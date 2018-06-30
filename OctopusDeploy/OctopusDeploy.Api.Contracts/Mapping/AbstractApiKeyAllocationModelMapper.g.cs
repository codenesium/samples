using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiKeyAllocationModelMapper
        {
                public virtual ApiKeyAllocationResponseModel MapRequestToResponse(
                        string collectionName,
                        ApiKeyAllocationRequestModel request)
                {
                        var response = new ApiKeyAllocationResponseModel();
                        response.SetProperties(collectionName,
                                               request.Allocated);
                        return response;
                }

                public virtual ApiKeyAllocationRequestModel MapResponseToRequest(
                        ApiKeyAllocationResponseModel response)
                {
                        var request = new ApiKeyAllocationRequestModel();
                        request.SetProperties(
                                response.Allocated);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>b54095c874fa78ca2839db5cc311e41a</Hash>
</Codenesium>*/