using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                public JsonPatchDocument<ApiReleaseRequestModel> CreatePatch(ApiReleaseRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiReleaseRequestModel>();
                        patch.Replace(x => x.Assembled, model.Assembled);
                        patch.Replace(x => x.ChannelId, model.ChannelId);
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.ProjectDeploymentProcessSnapshotId, model.ProjectDeploymentProcessSnapshotId);
                        patch.Replace(x => x.ProjectId, model.ProjectId);
                        patch.Replace(x => x.ProjectVariableSetSnapshotId, model.ProjectVariableSetSnapshotId);
                        patch.Replace(x => x.Version, model.Version);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>636f1f65d0728857ad99a72edd2b4012</Hash>
</Codenesium>*/