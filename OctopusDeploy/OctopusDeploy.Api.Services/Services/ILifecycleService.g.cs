using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface ILifecycleService
        {
                Task<CreateResponse<ApiLifecycleResponseModel>> Create(
                        ApiLifecycleRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiLifecycleRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiLifecycleResponseModel> Get(string id);

                Task<List<ApiLifecycleResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiLifecycleResponseModel> GetName(string name);
                Task<List<ApiLifecycleResponseModel>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>ca5056c5e851e0ef5979706c5c715854</Hash>
</Codenesium>*/