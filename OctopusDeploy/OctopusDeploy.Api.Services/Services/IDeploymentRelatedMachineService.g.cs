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

                Task<List<ApiDeploymentRelatedMachineResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiDeploymentRelatedMachineResponseModel>> GetDeploymentId(string deploymentId);
                Task<List<ApiDeploymentRelatedMachineResponseModel>> GetMachineId(string machineId);
        }
}

/*<Codenesium>
    <Hash>3ee90831aceafd83cd2e0d5925988554</Hash>
</Codenesium>*/