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

                Task<List<ApiDeploymentResponseModel>> GetChannelId(string channelId);

                Task<List<ApiDeploymentResponseModel>> GetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(string id, string projectId, string projectGroupId, string name, DateTimeOffset created, string releaseId, string taskId, string environmentId);

                Task<List<ApiDeploymentResponseModel>> GetTenantId(string tenantId);

                Task<List<ApiDeploymentRelatedMachineResponseModel>> DeploymentRelatedMachines(string deploymentId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>fa8fd6b51948d48729e0c142afe1bac1</Hash>
</Codenesium>*/