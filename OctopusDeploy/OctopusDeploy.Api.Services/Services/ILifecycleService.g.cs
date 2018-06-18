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

                Task<List<ApiLifecycleResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiLifecycleResponseModel> GetName(string name);
                Task<List<ApiLifecycleResponseModel>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>d8ecda2833f781269e594e522d804aa6</Hash>
</Codenesium>*/