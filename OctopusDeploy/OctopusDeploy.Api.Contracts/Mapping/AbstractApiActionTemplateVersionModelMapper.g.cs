using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiActionTemplateVersionModelMapper
        {
                public virtual ApiActionTemplateVersionResponseModel MapRequestToResponse(
                        string id,
                        ApiActionTemplateVersionRequestModel request)
                {
                        var response = new ApiActionTemplateVersionResponseModel();
                        response.SetProperties(id,
                                               request.ActionType,
                                               request.JSON,
                                               request.LatestActionTemplateId,
                                               request.Name,
                                               request.Version);
                        return response;
                }

                public virtual ApiActionTemplateVersionRequestModel MapResponseToRequest(
                        ApiActionTemplateVersionResponseModel response)
                {
                        var request = new ApiActionTemplateVersionRequestModel();
                        request.SetProperties(
                                response.ActionType,
                                response.JSON,
                                response.LatestActionTemplateId,
                                response.Name,
                                response.Version);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>66c1c00a2667aeb98c40939211708134</Hash>
</Codenesium>*/