using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IWorkerTaskLeaseService
        {
                Task<CreateResponse<ApiWorkerTaskLeaseResponseModel>> Create(
                        ApiWorkerTaskLeaseRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiWorkerTaskLeaseRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiWorkerTaskLeaseResponseModel> Get(string id);

                Task<List<ApiWorkerTaskLeaseResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>793365d7f26a4a52efbdb65a3afa4460</Hash>
</Codenesium>*/