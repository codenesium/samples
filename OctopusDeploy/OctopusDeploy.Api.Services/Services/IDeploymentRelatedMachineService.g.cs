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

                Task<UpdateResponse<ApiDeploymentRelatedMachineResponseModel>> Update(int id,
                                                                                       ApiDeploymentRelatedMachineRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiDeploymentRelatedMachineResponseModel> Get(int id);

                Task<List<ApiDeploymentRelatedMachineResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiDeploymentRelatedMachineResponseModel>> ByDeploymentId(string deploymentId);

                Task<List<ApiDeploymentRelatedMachineResponseModel>> ByMachineId(string machineId);
        }
}

/*<Codenesium>
    <Hash>1fa9871be727f02ae97a9e6b9e17df10</Hash>
</Codenesium>*/