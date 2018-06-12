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

                Task<List<ApiWorkerTaskLeaseResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>b4fea64178293fa503b58c46c6d051a0</Hash>
</Codenesium>*/