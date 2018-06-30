using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiCommunityActionTemplateModelMapper
        {
                public virtual ApiCommunityActionTemplateResponseModel MapRequestToResponse(
                        string id,
                        ApiCommunityActionTemplateRequestModel request)
                {
                        var response = new ApiCommunityActionTemplateResponseModel();
                        response.SetProperties(id,
                                               request.ExternalId,
                                               request.JSON,
                                               request.Name);
                        return response;
                }

                public virtual ApiCommunityActionTemplateRequestModel MapResponseToRequest(
                        ApiCommunityActionTemplateResponseModel response)
                {
                        var request = new ApiCommunityActionTemplateRequestModel();
                        request.SetProperties(
                                response.ExternalId,
                                response.JSON,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>be14a482acb3442821196844612067e3</Hash>
</Codenesium>*/