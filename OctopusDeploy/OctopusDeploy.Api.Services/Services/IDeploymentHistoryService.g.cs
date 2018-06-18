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

                Task<List<ApiDeploymentHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiDeploymentHistoryResponseModel>> GetCreated(DateTimeOffset created);
        }
}

/*<Codenesium>
    <Hash>db293c59e00deca691ed06c82195ec95</Hash>
</Codenesium>*/