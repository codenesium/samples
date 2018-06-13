using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDeploymentRelatedMachineService
        {
                Task<CreateResponse<ApiDeploymentRelatedMachineResponseModel>> Create(
                        ApiDeploymentRelatedMachineRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiDeploymentRelatedMachineRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiDeploymentRelatedMachineResponseModel> Get(int id);

                Task<List<ApiDeploymentRelatedMachineResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiDeploymentRelatedMachineResponseModel>> GetDeploymentId(string deploymentId);
                Task<List<ApiDeploymentRelatedMachineResponseModel>> GetMachineId(string machineId);
        }
}

/*<Codenesium>
    <Hash>5f9b7b62aa8f8f03f9a066ebf6b34e8c</Hash>
</Codenesium>*/