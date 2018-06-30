using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiInterruptionModelMapper
        {
                public virtual ApiInterruptionResponseModel MapRequestToResponse(
                        string id,
                        ApiInterruptionRequestModel request)
                {
                        var response = new ApiInterruptionResponseModel();
                        response.SetProperties(id,
                                               request.Created,
                                               request.EnvironmentId,
                                               request.JSON,
                                               request.ProjectId,
                                               request.RelatedDocumentIds,
                                               request.ResponsibleTeamIds,
                                               request.Status,
                                               request.TaskId,
                                               request.TenantId,
                                               request.Title);
                        return response;
                }

                public virtual ApiInterruptionRequestModel MapResponseToRequest(
                        ApiInterruptionResponseModel response)
                {
                        var request = new ApiInterruptionRequestModel();
                        request.SetProperties(
                                response.Created,
                                response.EnvironmentId,
                                response.JSON,
                                response.ProjectId,
                                response.RelatedDocumentIds,
                                response.ResponsibleTeamIds,
                                response.Status,
                                response.TaskId,
                                response.TenantId,
                                response.Title);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>06852b912463edad5cfd618b99911a6a</Hash>
</Codenesium>*/