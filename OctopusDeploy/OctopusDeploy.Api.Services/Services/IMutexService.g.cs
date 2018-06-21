using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IMutexService
        {
                Task<CreateResponse<ApiMutexResponseModel>> Create(
                        ApiMutexRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiMutexRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiMutexResponseModel> Get(string id);

                Task<List<ApiMutexResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>f04a8110633e7871a02309df0e6a0637</Hash>
</Codenesium>*/