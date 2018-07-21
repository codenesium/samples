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

                Task<UpdateResponse<ApiWorkerPoolResponseModel>> Update(string id,
                                                                         ApiWorkerPoolRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiWorkerPoolResponseModel> Get(string id);

                Task<List<ApiWorkerPoolResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiWorkerPoolResponseModel> ByName(string name);
        }
}

/*<Codenesium>
    <Hash>a5eb85036e8843134ebb3303a8863ab2</Hash>
</Codenesium>*/