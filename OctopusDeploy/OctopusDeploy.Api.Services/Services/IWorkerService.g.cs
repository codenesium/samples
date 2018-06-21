using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>0d58f78e6d84781203e59652b563e7f3</Hash>
</Codenesium>*/