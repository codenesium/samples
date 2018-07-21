using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IReleaseService
        {
                Task<CreateResponse<ApiReleaseResponseModel>> Create(
                        ApiReleaseRequestModel model);

                Task<UpdateResponse<ApiReleaseResponseModel>> Update(string id,
                                                                      ApiReleaseRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiReleaseResponseModel> Get(string id);

                Task<List<ApiReleaseResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiReleaseResponseModel> ByVersionProjectId(string version, string projectId);

                Task<List<ApiReleaseResponseModel>> ByIdAssembled(string id, DateTimeOffset assembled);

                Task<List<ApiReleaseResponseModel>> ByProjectDeploymentProcessSnapshotId(string projectDeploymentProcessSnapshotId);

                Task<List<ApiReleaseResponseModel>> ByIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(string id, string version, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string channelId, DateTimeOffset assembled);

                Task<List<ApiReleaseResponseModel>> ByIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(string id, string channelId, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string version, DateTimeOffset assembled);
        }
}

/*<Codenesium>
    <Hash>daf29466656ad2a8e11b0e7cf6e3d43a</Hash>
</Codenesium>*/