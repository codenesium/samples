using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiProjectGroupModelMapper
        {
                public virtual ApiProjectGroupResponseModel MapRequestToResponse(
                        string id,
                        ApiProjectGroupRequestModel request)
                {
                        var response = new ApiProjectGroupResponseModel();
                        response.SetProperties(id,
                                               request.DataVersion,
                                               request.JSON,
                                               request.Name);
                        return response;
                }

                public virtual ApiProjectGroupRequestModel MapResponseToRequest(
                        ApiProjectGroupResponseModel response)
                {
                        var request = new ApiProjectGroupRequestModel();
                        request.SetProperties(
                                response.DataVersion,
                                response.JSON,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>947a233183c6d09dd697db978c9cc3e6</Hash>
</Codenesium>*/