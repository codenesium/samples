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

                Task<List<ApiWorkerTaskLeaseResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>3b0699e9c9b1cef7d77466530d5bc254</Hash>
</Codenesium>*/