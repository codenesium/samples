using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiActionTemplateModelMapper
        {
                public virtual ApiActionTemplateResponseModel MapRequestToResponse(
                        string id,
                        ApiActionTemplateRequestModel request)
                {
                        var response = new ApiActionTemplateResponseModel();
                        response.SetProperties(id,
                                               request.ActionType,
                                               request.CommunityActionTemplateId,
                                               request.JSON,
                                               request.Name,
                                               request.Version);
                        return response;
                }

                public virtual ApiActionTemplateRequestModel MapResponseToRequest(
                        ApiActionTemplateResponseModel response)
                {
                        var request = new ApiActionTemplateRequestModel();
                        request.SetProperties(
                                response.ActionType,
                                response.CommunityActionTemplateId,
                                response.JSON,
                                response.Name,
                                response.Version);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>d9e48c6e7903fe52269c1ecc609a1a58</Hash>
</Codenesium>*/