using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiLifecycleModelMapper
        {
                public virtual ApiLifecycleResponseModel MapRequestToResponse(
                        string id,
                        ApiLifecycleRequestModel request)
                {
                        var response = new ApiLifecycleResponseModel();
                        response.SetProperties(id,
                                               request.DataVersion,
                                               request.JSON,
                                               request.Name);
                        return response;
                }

                public virtual ApiLifecycleRequestModel MapResponseToRequest(
                        ApiLifecycleResponseModel response)
                {
                        var request = new ApiLifecycleRequestModel();
                        request.SetProperties(
                                response.DataVersion,
                                response.JSON,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>d9ecd432bd9b10a526dd62970090f130</Hash>
</Codenesium>*/