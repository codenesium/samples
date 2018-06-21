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

                Task<ActionResponse> Update(string id,
                                            ApiReleaseRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiReleaseResponseModel> Get(string id);

                Task<List<ApiReleaseResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiReleaseResponseModel> GetVersionProjectId(string version, string projectId);

                Task<List<ApiReleaseResponseModel>> GetIdAssembled(string id, DateTimeOffset assembled);

                Task<List<ApiReleaseResponseModel>> GetProjectDeploymentProcessSnapshotId(string projectDeploymentProcessSnapshotId);

                Task<List<ApiReleaseResponseModel>> GetIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(string id, string version, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string channelId, DateTimeOffset assembled);

                Task<List<ApiReleaseResponseModel>> GetIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(string id, string channelId, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string version, DateTimeOffset assembled);
        }
}

/*<Codenesium>
    <Hash>607312529684ed9b3a892f5f96c7a162</Hash>
</Codenesium>*/