using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiReleaseModelMapper
        {
                public virtual ApiReleaseResponseModel MapRequestToResponse(
                        string id,
                        ApiReleaseRequestModel request)
                {
                        var response = new ApiReleaseResponseModel();
                        response.SetProperties(id,
                                               request.Assembled,
                                               request.ChannelId,
                                               request.JSON,
                                               request.ProjectDeploymentProcessSnapshotId,
                                               request.ProjectId,
                                               request.ProjectVariableSetSnapshotId,
                                               request.Version);
                        return response;
                }

                public virtual ApiReleaseRequestModel MapResponseToRequest(
                        ApiReleaseResponseModel response)
                {
                        var request = new ApiReleaseRequestModel();
                        request.SetProperties(
                                response.Assembled,
                                response.ChannelId,
                                response.JSON,
                                response.ProjectDeploymentProcessSnapshotId,
                                response.ProjectId,
                                response.ProjectVariableSetSnapshotId,
                                response.Version);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>3bb18d28a93f25f180d124f25e1fef9d</Hash>
</Codenesium>*/