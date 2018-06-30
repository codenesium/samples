using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiMutexModelMapper
        {
                public virtual ApiMutexResponseModel MapRequestToResponse(
                        string id,
                        ApiMutexRequestModel request)
                {
                        var response = new ApiMutexResponseModel();
                        response.SetProperties(id,
                                               request.JSON);
                        return response;
                }

                public virtual ApiMutexRequestModel MapResponseToRequest(
                        ApiMutexResponseModel response)
                {
                        var request = new ApiMutexRequestModel();
                        request.SetProperties(
                                response.JSON);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>2f99a82e79b74f67689a635e1cc755f2</Hash>
</Codenesium>*/