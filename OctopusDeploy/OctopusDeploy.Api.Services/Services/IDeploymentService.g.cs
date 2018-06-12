using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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

                Task<List<ApiDeploymentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiDeploymentResponseModel>> GetChannelId(string channelId);
                Task<List<ApiDeploymentResponseModel>> GetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(string id, string projectId, string projectGroupId, string name, DateTime created, string releaseId, string taskId, string environmentId);
                Task<List<ApiDeploymentResponseModel>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>a8c79b7c398863793c2dccfa31f0c691</Hash>
</Codenesium>*/