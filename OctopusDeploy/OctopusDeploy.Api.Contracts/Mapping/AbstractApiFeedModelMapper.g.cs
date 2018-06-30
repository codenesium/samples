using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiFeedModelMapper
        {
                public virtual ApiFeedResponseModel MapRequestToResponse(
                        string id,
                        ApiFeedRequestModel request)
                {
                        var response = new ApiFeedResponseModel();
                        response.SetProperties(id,
                                               request.FeedType,
                                               request.FeedUri,
                                               request.JSON,
                                               request.Name);
                        return response;
                }

                public virtual ApiFeedRequestModel MapResponseToRequest(
                        ApiFeedResponseModel response)
                {
                        var request = new ApiFeedRequestModel();
                        request.SetProperties(
                                response.FeedType,
                                response.FeedUri,
                                response.JSON,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>6010d75165cbf71349de8eec6f7bc3da</Hash>
</Codenesium>*/