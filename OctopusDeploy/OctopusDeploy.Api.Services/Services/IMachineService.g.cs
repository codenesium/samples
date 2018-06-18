using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IMachineService
        {
                Task<CreateResponse<ApiMachineResponseModel>> Create(
                        ApiMachineRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiMachineRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiMachineResponseModel> Get(string id);

                Task<List<ApiMachineResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiMachineResponseModel> GetName(string name);
                Task<List<ApiMachineResponseModel>> GetMachinePolicyId(string machinePolicyId);
        }
}

/*<Codenesium>
    <Hash>e3dd8bf4e44869688a59d0b1360c2b78</Hash>
</Codenesium>*/