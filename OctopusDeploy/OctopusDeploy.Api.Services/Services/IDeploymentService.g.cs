using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IDeploymentService
        {
                Task<CreateResponse<ApiDeploymentResponseModel>> Create(
                        ApiDeploymentRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiDeploymentRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiDeploymentResponseModel> Get(string id);

                Task<List<ApiDeploymentResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiDeploymentResponseModel>> ByChannelId(string channelId);

                Task<List<ApiDeploymentResponseModel>> ByIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(string id, string projectId, string projectGroupId, string name, DateTimeOffset created, string releaseId, string taskId, string environmentId);

                Task<List<ApiDeploymentResponseModel>> ByTenantId(string tenantId);

                Task<List<ApiDeploymentRelatedMachineResponseModel>> DeploymentRelatedMachines(string deploymentId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>3dc97ca7c5e3cd6a66cb7c8c3b8514e3</Hash>
</Codenesium>*/