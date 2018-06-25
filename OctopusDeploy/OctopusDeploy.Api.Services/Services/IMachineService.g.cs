using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<ApiMachineResponseModel> ByName(string name);

                Task<List<ApiMachineResponseModel>> ByMachinePolicyId(string machinePolicyId);
        }
}

/*<Codenesium>
    <Hash>036b0cd895aefb3fb3cfadddaaec2860</Hash>
</Codenesium>*/