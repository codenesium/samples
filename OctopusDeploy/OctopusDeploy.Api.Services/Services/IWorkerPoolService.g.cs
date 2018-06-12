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

                Task<List<ApiWorkerPoolResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiWorkerPoolResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>ef6ac4daeeb01237c1207743781688c3</Hash>
</Codenesium>*/