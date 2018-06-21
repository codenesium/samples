using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>fa5f1d2e179d560332974a575d449231</Hash>
</Codenesium>*/