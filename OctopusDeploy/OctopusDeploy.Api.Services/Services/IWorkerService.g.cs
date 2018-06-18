using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IWorkerService
        {
                Task<CreateResponse<ApiWorkerResponseModel>> Create(
                        ApiWorkerRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiWorkerRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiWorkerResponseModel> Get(string id);

                Task<List<ApiWorkerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiWorkerResponseModel> GetName(string name);
                Task<List<ApiWorkerResponseModel>> GetMachinePolicyId(string machinePolicyId);
        }
}

/*<Codenesium>
    <Hash>6b2db4b853b8917ce9c8a0381d4aaaad</Hash>
</Codenesium>*/