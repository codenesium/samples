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

                Task<ApiMachineResponseModel> GetName(string name);

                Task<List<ApiMachineResponseModel>> GetMachinePolicyId(string machinePolicyId);
        }
}

/*<Codenesium>
    <Hash>6f0070a52a541f33fc3621ccdbf212fd</Hash>
</Codenesium>*/