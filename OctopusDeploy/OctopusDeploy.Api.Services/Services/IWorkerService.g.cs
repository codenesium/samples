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

                Task<List<ApiWorkerResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiWorkerResponseModel> GetName(string name);
                Task<List<ApiWorkerResponseModel>> GetMachinePolicyId(string machinePolicyId);
        }
}

/*<Codenesium>
    <Hash>4238a0d3364ec8623df7a293c0143d6c</Hash>
</Codenesium>*/