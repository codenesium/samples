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

                Task<List<ApiMachineResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiMachineResponseModel> GetName(string name);
                Task<List<ApiMachineResponseModel>> GetMachinePolicyId(string machinePolicyId);
        }
}

/*<Codenesium>
    <Hash>bdd49f3c5f45f0c4109e04c66c54c1a1</Hash>
</Codenesium>*/