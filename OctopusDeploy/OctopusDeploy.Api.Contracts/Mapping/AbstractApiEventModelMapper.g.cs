using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiEventModelMapper
        {
                public virtual ApiEventResponseModel MapRequestToResponse(
                        string id,
                        ApiEventRequestModel request)
                {
                        var response = new ApiEventResponseModel();
                        response.SetProperties(id,
                                               request.AutoId,
                                               request.Category,
                                               request.EnvironmentId,
                                               request.JSON,
                                               request.Message,
                                               request.Occurred,
                                               request.ProjectId,
                                               request.RelatedDocumentIds,
                                               request.TenantId,
                                               request.UserId,
                                               request.Username);
                        return response;
                }

                public virtual ApiEventRequestModel MapResponseToRequest(
                        ApiEventResponseModel response)
                {
                        var request = new ApiEventRequestModel();
                        request.SetProperties(
                                response.AutoId,
                                response.Category,
                                response.EnvironmentId,
                                response.JSON,
                                response.Message,
                                response.Occurred,
                                response.ProjectId,
                                response.RelatedDocumentIds,
                                response.TenantId,
                                response.UserId,
                                response.Username);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>e6257ec8bebf2cdfd23f729681295362</Hash>
</Codenesium>*/