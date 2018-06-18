using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>e79b209ad06fcfcbc3a938edda9ab41c</Hash>
</Codenesium>*/