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

                Task<ApiWorkerPoolResponseModel> ByName(string name);
        }
}

/*<Codenesium>
    <Hash>ecc36d8d44d96f767e256481711a7fe2</Hash>
</Codenesium>*/