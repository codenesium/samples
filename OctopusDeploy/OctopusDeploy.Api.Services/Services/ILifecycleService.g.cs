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

                Task<List<ApiLifecycleResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiLifecycleResponseModel> GetName(string name);
                Task<List<ApiLifecycleResponseModel>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>334a2ee0b44b1db0983e4a86c6e126c5</Hash>
</Codenesium>*/