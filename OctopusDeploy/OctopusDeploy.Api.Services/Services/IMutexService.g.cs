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

                Task<List<ApiMutexResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>26cc670c5a93c8398adda2bb55744b99</Hash>
</Codenesium>*/