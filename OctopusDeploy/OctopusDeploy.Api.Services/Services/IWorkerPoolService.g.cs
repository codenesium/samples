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

                Task<List<ApiWorkerPoolResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiWorkerPoolResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>34778a6f1563b7b8b6a74109f65c61fb</Hash>
</Codenesium>*/