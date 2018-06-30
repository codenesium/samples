using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiApiKeyModelMapper
        {
                public virtual ApiApiKeyResponseModel MapRequestToResponse(
                        string id,
                        ApiApiKeyRequestModel request)
                {
                        var response = new ApiApiKeyResponseModel();
                        response.SetProperties(id,
                                               request.ApiKeyHashed,
                                               request.Created,
                                               request.JSON,
                                               request.UserId);
                        return response;
                }

                public virtual ApiApiKeyRequestModel MapResponseToRequest(
                        ApiApiKeyResponseModel response)
                {
                        var request = new ApiApiKeyRequestModel();
                        request.SetProperties(
                                response.ApiKeyHashed,
                                response.Created,
                                response.JSON,
                                response.UserId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>daca61e183ae89b043c3dbd2713327b3</Hash>
</Codenesium>*/