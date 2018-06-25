using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiDeploymentRelatedMachineResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiDeploymentRelatedMachineResponseModel>> ByDeploymentId(string deploymentId);

                Task<List<ApiDeploymentRelatedMachineResponseModel>> ByMachineId(string machineId);
        }
}

/*<Codenesium>
    <Hash>5a165f4e8dd7ac9cf3a6d12992ac2a92</Hash>
</Codenesium>*/