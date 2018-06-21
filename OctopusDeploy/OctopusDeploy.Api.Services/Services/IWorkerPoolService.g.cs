using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiWorkerPoolResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiWorkerPoolResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>2a27e16833847f165668299ba0cf8b50</Hash>
</Codenesium>*/