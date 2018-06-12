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

                Task<List<ApiMutexResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>5fdb0e6e3d8362c2a0a0cbcd60f62dea</Hash>
</Codenesium>*/