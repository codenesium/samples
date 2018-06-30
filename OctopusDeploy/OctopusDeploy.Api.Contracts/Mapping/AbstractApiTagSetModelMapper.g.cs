using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiTagSetModelMapper
        {
                public virtual ApiTagSetResponseModel MapRequestToResponse(
                        string id,
                        ApiTagSetRequestModel request)
                {
                        var response = new ApiTagSetResponseModel();
                        response.SetProperties(id,
                                               request.DataVersion,
                                               request.JSON,
                                               request.Name,
                                               request.SortOrder);
                        return response;
                }

                public virtual ApiTagSetRequestModel MapResponseToRequest(
                        ApiTagSetResponseModel response)
                {
                        var request = new ApiTagSetRequestModel();
                        request.SetProperties(
                                response.DataVersion,
                                response.JSON,
                                response.Name,
                                response.SortOrder);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>7338fc2461a91a5c0c710805453d7268</Hash>
</Codenesium>*/