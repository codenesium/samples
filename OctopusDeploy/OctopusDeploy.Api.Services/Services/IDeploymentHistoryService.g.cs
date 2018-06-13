using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDeploymentHistoryService
        {
                Task<CreateResponse<ApiDeploymentHistoryResponseModel>> Create(
                        ApiDeploymentHistoryRequestModel model);

                Task<ActionResponse> Update(string deploymentId,
                                            ApiDeploymentHistoryRequestModel model);

                Task<ActionResponse> Delete(string deploymentId);

                Task<ApiDeploymentHistoryResponseModel> Get(string deploymentId);

                Task<List<ApiDeploymentHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiDeploymentHistoryResponseModel>> GetCreated(DateTimeOffset created);
        }
}

/*<Codenesium>
    <Hash>58f49602a017abf96f24046a6d881293</Hash>
</Codenesium>*/