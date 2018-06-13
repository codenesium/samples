using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IWorkerPoolService
        {
                Task<CreateResponse<ApiWorkerPoolResponseModel>> Create(
                        ApiWorkerPoolRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiWorkerPoolRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiWorkerPoolResponseModel> Get(string id);

                Task<List<ApiWorkerPoolResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiWorkerPoolResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>1b26c2b10a18a2155eec307ef73a2c51</Hash>
</Codenesium>*/