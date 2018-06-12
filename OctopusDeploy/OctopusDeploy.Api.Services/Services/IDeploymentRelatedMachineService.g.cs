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

                Task<List<ApiDeploymentRelatedMachineResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiDeploymentRelatedMachineResponseModel>> GetDeploymentId(string deploymentId);
                Task<List<ApiDeploymentRelatedMachineResponseModel>> GetMachineId(string machineId);
        }
}

/*<Codenesium>
    <Hash>9ece6a526ede0adec1b88a345fba9703</Hash>
</Codenesium>*/