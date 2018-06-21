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

                Task<List<ApiDeploymentRelatedMachineResponseModel>> GetDeploymentId(string deploymentId);

                Task<List<ApiDeploymentRelatedMachineResponseModel>> GetMachineId(string machineId);
        }
}

/*<Codenesium>
    <Hash>9e8aecf7bc2c7bdab083dda0b62436cd</Hash>
</Codenesium>*/